using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserGroupsManagment.Model;
using UserGroupsManagment.Model.Contractors;
using UserGroupsManagment.Model.Filters;
using UserGroupsManagment.Service.Contractors;
using Xunit;

namespace UserGroupsManagment.Test.Service
{
    public class UserService
    {
        public IUserService Service { get; }
        public UserService(IUserService service, IMapper mapper)
        {
            Service = service;
        }
        [Fact]
        public async void AddUser()
        {
            IUser user = new User() { Name = "test", Email = "test@test.com", Password = "test123123" };
            user = await Service.AddOne(user);
            Assert.Contains(await Service.GetAll(), e => e.Id == user.Id);
        }
        [Fact]
        public async void DeleteUser ()
        {
            IUser user = new User() { Name = "test", Email = "test@test.com", Password = "test123123" };
            user = await Service.AddOne(user);
            await Service.DeleteOne(user.Id);
            Assert.DoesNotContain(await Service.GetAll(), e => e.Id == user.Id);
        }
        [Fact]
        public async void UpdateUser()
        {
            IUser user = new User() { Name = "test", Email = "test@test.com", Password = "test123123" };
            user = await Service.AddOne(user);
            Assert.Equal("test", user.Name);
            user.Name = "test 2";
            user = await Service.UpdateOne(user);
            Assert.Equal("test 2", user.Name);

        }
        [Fact]
        public async void GetOneUser()
        {
            IUser user = new User() { Name = "test", Email = "test@test.com", Password = "test123123" };
            user = await Service.AddOne(user);
            Assert.Equal(user.Id, (await Service.GetOne(user.Id)).Id);
        }
        [Fact]
        public async void GetOneUserByFilter()
        {
            IUser user = new User() { Name = "test", Email = "test@test.com", Password = "test123123" };
            user = await Service.AddOne(user);
            //find by id
            var filter = new UserFilter();
            filter.Id = user.Id;
            Assert.NotNull(await Service.GetOneByFilter(filter));
            // find by name
            filter = new UserFilter();
            filter.Name = "test";
            Assert.NotNull(await Service.GetOneByFilter(filter));

        }
    }
}
