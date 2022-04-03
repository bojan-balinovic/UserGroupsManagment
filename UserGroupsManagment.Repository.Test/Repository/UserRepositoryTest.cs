using System;
using System.Linq;
using UserGroupsManagment.Model;
using UserGroupsManagment.Model.Contractors;
using UserGroupsManagment.Model.Filters;
using UserGroupsManagment.Repository.Contractors;
using Xunit;

namespace UserGroupsManagment.Repository.Test
{
    public class UserRepositoryTest
    {
        public UserRepositoryTest(IUserRepository repository)
        {
            Repository = repository;
        }

        public IUserRepository Repository { get; }

        [Fact]
        public async void GetAll()
        {
            IUser user = new User();
            user.Email = "test@test.com";
            user.Name = "Test";
            user.Password = "test";
            await Repository.AddOne(user);
            var models=await Repository.GetAll();
            Assert.Single(models);
        }
    }
}
