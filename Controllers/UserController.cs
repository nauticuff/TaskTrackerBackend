using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskTrackerBackend.Models.DTO;
using TaskTrackerBackend.Services;

namespace TaskTrackerBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly UserService _data;
        public UserController(UserService dataFromService)
        {
            _data = dataFromService;
        }
        //Login
        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginDTO User)
        {
            return _data.Login(User);
        }

        //Add a user
        [HttpPost("AddUser")]
            //if user already exists
            //if they do not exist we can then have the acc created
            //else throw a false
            
            public bool AddUser(CreateAccountDTO UserToAdd)
            {
                return _data.AddUser(UserToAdd);
            }

        //Update user account

        //Delete user account
    }
}