using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTrackerBackend.Models;
using TaskTrackerBackend.Models.DTO;
using TaskTrackerBackend.Services.Context;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;

namespace TaskTrackerBackend.Services
{
    public class UserService : ControllerBase
    {
        private readonly DataContext _context;
        public UserService(DataContext context)
        {
            _context = context;
        }

        public bool DoesUserExist(string? Username)
        {
            //check the table to see if the username exists
            //if 1 item matches the condition we will return the item
            //if no item matches the ocnditiion it will return null
            //if multiple items match then error will occur
            return _context.UserInfo.SingleOrDefault(user => user.UserName == Username) != null;

        }
        public bool AddUser(CreateAccountDTO UserToAdd)
        {
            //if user already exists
            //if they do not exist then create acc
            bool result = false;
            if (!DoesUserExist(UserToAdd.UserName))
            {
                //The user does not exist 
                //creating a new instance of user model (empty object)
                UserModel newUser = new UserModel();
                var hashPassword = HashPassword(UserToAdd.Password);
                newUser.ID = UserToAdd.ID;
                newUser.UserName = UserToAdd.UserName;
                newUser.Salt = hashPassword.Salt;
                newUser.Hash = hashPassword.Hash;

                _context.Add(newUser);

                result = _context.SaveChanges() != 0;
            }

            return result;
            //else throw a false
        }

        public PasswordDTO HashPassword(string? Password)
        {
            PasswordDTO newHashedPassword = new PasswordDTO();

            byte[] SaltByte = new byte[64];
            var provider = new RNGCryptoServiceProvider();
            provider.GetNonZeroBytes(SaltByte);

            var Salt = Convert.ToBase64String(SaltByte);
            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(Password, SaltByte, 10000);
            var Hash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            newHashedPassword.Salt = Salt;
            newHashedPassword.Hash = Hash;

            return newHashedPassword;
        }

        public bool VerifyUserPassword(string? Password, string? storedHash, string? storedSalt)
        {
            var SaltBytes = Convert.FromBase64String(storedSalt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(Password, SaltBytes, 10000);
            var newHash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));
            return newHash == storedHash;
        }
        public IActionResult Login(LoginDTO User)
        {
            //return error code if user does not have valid username or pw.
            IActionResult Result = Unauthorized();

            //check to see does user exist
            if (DoesUserExist(User.UserName))
            {
                //true
                //want to store user object
                //create another helper function
                UserModel foundUser = GetUserByUsername(User.UserName);
                //check if pw is correct
                if (VerifyUserPassword(User.Password, foundUser.Hash, foundUser.Salt))
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var tokeOptions = new JwtSecurityToken(
                        issuer: "http://localhost:5000",
                        audience: "http://localhost:5000",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: signinCredentials
                    );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                    Result = Ok(new { Token = tokenString });
                }
            }

            return Result;

        }

        public UserModel GetUserByUsername(string? username)
        {
            return _context.UserInfo.SingleOrDefault(user => user.UserName == username);
        }
    }
}