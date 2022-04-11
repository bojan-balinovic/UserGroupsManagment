using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserGroupsManagment.Model;
using UserGroupsManagment.Model.Contractors;
using UserGroupsManagment.Repository;
using UserGroupsManagment.Repository.Contractors;
using UserGroupsManagment.Service;
using UserGroupsManagment.Service.Contractors;
using UserGroupsManagment.ViewModels;
using Xunit;

namespace UserGroupsManagment.Test.Service
{
    public class GroupService
    {
        public IGroupService Service { get; }

        public IUserService UserService { get; }
        public IMapper Mapper { get; }

        public GroupService(IUnitOfWork unitOfWork, IUserService userService, IGroupService groupService, IMapper mapper)
        {
            Service = groupService;
            UserService = userService;
            Mapper = mapper;
        }

        [Fact]
        public async void AddGroup()
        {
            var group = new Group();
            group.Name = "Grupa 1";
            var newGroup = await Service.AddOne(group);
            Assert.NotNull(newGroup);
        }
        [Fact]
        public async void AddGroupWithUsers()
        {
            var group = new Group() { Name = "Grupa 1" };
            User user1 = new User() { Name = "test1", Password = "12345678", Email = "test@test.com" };
            User user2 = new User() { Name = "test2", Password = "12345678", Email = "test2@test.com" };
            group.Users = new List<User>();
            group.Users.Add(user1);
            group.Users.Add(user2);
            IGroup newGroup = await Service.AddOne(group);
            newGroup = await Service.GetOneByFilter(
                new Model.Filters.GroupFilter() { Id = newGroup.Id }
                );
            Assert.NotNull(newGroup);
            Assert.Equal(2, newGroup.Users.Count()); 

        }
        [Fact]
        public async void UpdateGroup()
        {
            // Creating group
            var group = new Group() { Name = "Grupa 1" };
            User user1 = new User() { Name = "test1", Password = "12345678", Email = "test@test.com" };
            User user2 = new User() { Name = "test2", Password = "12345678", Email = "test2@test.com" };
            group.Users = new List<User>();
            group.Users.Add(user1);
            group.Users.Add(user2);
            IGroup newGroup = await Service.AddOne(group);
 
            Assert.NotNull(newGroup);
            Assert.Equal(2, newGroup.Users.Count());

            // Updating group
            newGroup.Name = "Grupa test";
            // Adding new user to group
            IUser user3 = new User() { Name = "test3", Password = "12345678", Email = "test3@test.com" };
            user3 = await UserService.AddOne(user3);
            newGroup.Users.Add((User)user3);
            newGroup = await Service.UpdateOne(newGroup);
         
            newGroup = await Service.GetOneByFilter(new Model.Filters.GroupFilter() { Id = newGroup.Id });
            Assert.Equal("Grupa test", newGroup.Name);
             Assert.Equal(3, newGroup.Users.Count());
        }
        [Fact]
        public async void DeleteGroup() {
            var group = new Group() { Name = "Grupa 1" };
            IGroup newGroup = await Service.AddOne(group);
            await Service.DeleteOne(newGroup.Id);
            Assert.DoesNotContain(await Service.GetAll(), e => e.Id == newGroup.Id);
        }
        [Fact]
        public async void CreateGroup()
        {
            var group = new Group() { Name = "Grupa 1" };
            IGroup newGroup = await Service.AddOne(group);
            Assert.Contains(await Service.GetAll(), e => e.Id == newGroup.Id);
        }
    }
}
