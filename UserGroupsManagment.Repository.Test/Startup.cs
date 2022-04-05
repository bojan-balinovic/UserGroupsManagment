using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using UserGroupsManagment.Repository;
using UserGroupsManagment.Repository.Contractors;
using UserGroupsManagment;

namespace UserGroupsManagment.Test
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            // database connection
            services.AddDbContext<MainContext>(options =>
            {
                options.UseInMemoryDatabase("database");
            });

            //Auto mapper
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
                mc.AddProfile(new RepositoryMappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
