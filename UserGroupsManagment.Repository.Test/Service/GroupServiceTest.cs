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
    public class GroupServiceTest
    {
        public IGroupService GroupService { get; }

        public IUserService UserService { get; }
        public IMapper Mapper { get; }

        public GroupServiceTest(IUnitOfWork unitOfWork, IUserService userService, IGroupService groupService, IMapper mapper)
        {
            GroupService = new GroupService(unitOfWork.GroupRepository);

            UserService = new UserService(unitOfWork.UserRepository);
            Mapper = mapper;
        }

        [Fact]
        public async void AddGroup()
        {
            var group = new Group();
            group.Name = "Grupa 1";
            var newGroup = await GroupService.AddOne(group);
            Assert.NotNull(newGroup);
        }
        [Fact]
        public async void AddGroupWithUsers()
        {
            var group = new Group() { Name = "Grupa 1" };
            IUser user1 = new User() { Name = "test1", Password = "12345678", Email = "test@test.com" };
            IUser user2 = new User() { Name = "test2", Password = "12345678", Email = "test2@test.com" };
            group.Users = new List<IUser>();
            group.Users.Add(user1);
            group.Users.Add(user2);
            IGroup newGroup = await GroupService.AddOne(group);
            newGroup = await GroupService.GetOneByFilter(
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
            IUser user1 = new User() { Name = "test1", Password = "12345678", Email = "test@test.com" };
            IUser user2 = new User() { Name = "test2", Password = "12345678", Email = "test2@test.com" };
            group.Users = new List<IUser>();
            group.Users.Add(user1);
            group.Users.Add(user2);
            IGroup newGroup = await GroupService.AddOne(group);
            newGroup = await GroupService.GetOneByFilter(
                new Model.Filters.GroupFilter() { Id = newGroup.Id }
                );
            Assert.NotNull(newGroup);
            Assert.Equal(2, newGroup.Users.Count());

            // Updating group
            newGroup.Name = "Grupa test";
            // Adding new user to group
            //IUser user3 = new User() { Name = "test3", Password = "12345678", Email = "test3@test.com" };
            //user3=await UserService.AddOne(user3);
            //newGroup.Users.Add(user3);
            newGroup = await GroupService.UpdateOne(newGroup);
          //  Assert.Equal(3, newGroup.Users.Count());
            Assert.Equal("Grupa test", newGroup.Name);
        }
    }
}
