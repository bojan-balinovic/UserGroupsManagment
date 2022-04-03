using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UserGroupsManagment.Entity;

namespace UserGroupsManagment.Repository
{
    public class MainContext:DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<GroupEntity> Groups { get; set; }
        public MainContext(DbContextOptions options) : base(options)
        {

        }

    }
}
