using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TaskTrackerBackend.Services.Context
{
    public class DataContext : DbContext
    {

        public DbSet<Models.UserModel> UserInfo { get; set; }
        public DbSet<Models.TaskModel> TaskInfo { get; set; }

        public DataContext(DbContextOptions options): base(options)
        {}

        protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);
        }

    }
}