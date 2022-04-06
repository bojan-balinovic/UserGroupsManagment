using Microsoft.Extensions.DependencyInjection;
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
        public IServiceProvider ServiceProvider { get; }
        public UserRepositoryTest(IServiceProvider serviceProvider)
        {

            ServiceProvider = serviceProvider;
        }
        public IUserRepository CreateRepositoryInstance()
        {
            return ServiceProvider.GetRequiredService<IUserRepository>();
        }

        [Fact]
        public async void GetAll()
        {
            var repository = CreateRepositoryInstance();
            IUser user = new User();
            user.Email = "test@test.com";
            user.Name = "Test";
            user.Password = "test";
            var newUser=await repository.AddOne(user);
            var models=await repository.GetAll();
            Assert.Contains(models, e=>e.Id==newUser.Id);
        }

        [Fact]
        public async void GetAllWithPagination()
        {
            var repository = CreateRepositoryInstance();
            IUser user1 = new User();
            user1.Email = "test@test.com";
            user1.Name = "Test";
            user1.Password = "test";
            user1=await repository.AddOne(user1);
            IUser user2 = new User();
            user2.Email = "test2@test.com";
            user2.Name = "Test2";
            user2.Password = "test2";
            user2=await repository.AddOne(user2);
            var filter = new UserFilter() { CurrentPage = 1, PageSize = 10 };
            var pagination = await repository.GetManyByFilter(filter);
            Assert.Contains(pagination.Items, e=>e.Id==user1.Id);
            Assert.Contains(pagination.Items, e => e.Id == user2.Id);
            Assert.Equal(1, pagination.CurrentPage);
            Assert.Equal(10, pagination.PageSize);
        }

        [Fact]
        public async void AddOne()
        {
            var repository = CreateRepositoryInstance();
            var user = new User();
            user.Name = "test123123";
            user.Password = "test123123";
            user.Email = "test@test.com";
            var newUser = await repository.AddOne(user);
            Assert.NotNull(newUser);
        }
        [Fact]
        public async void DeleteOne()
        {
            var repository = CreateRepositoryInstance();
            var user = new User();
            user.Name = "test123123";
            user.Password = "test123123";
            user.Email = "test@test.com";
            var newUser = await repository.AddOne(user);
            Assert.NotNull(newUser);

            await repository.DeleteOne(newUser.Id);

        }
    }
}
