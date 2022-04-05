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
            await repository.AddOne(user);
            var models=await repository.GetAll();
            Assert.Single(models);
        }

        [Fact]
        public async void GetAllWithPagination()
        {
            var repository = CreateRepositoryInstance();
            IUser user = new User();
            user.Email = "test@test.com";
            user.Name = "Test";
            user.Password = "test";
            await repository.AddOne(user);
            user.Email = "test2@test.com";
            user.Name = "Test2";
            user.Password = "test2";
            await repository.AddOne(user);
            var filter = new UserFilter() { CurrentPage = 1, PageSize = 10 };
            var pagination = await repository.GetManyByFilter(filter);
            Assert.Equal(2, pagination.Items.Count());
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
