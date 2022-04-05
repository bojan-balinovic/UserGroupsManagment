using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UserGroupsManagment.Entity;
using UserGroupsManagment.Model;
using UserGroupsManagment.Model.Contractors;

namespace UserGroupsManagment.Repository
{
    public class RepositoryMappingProfile:Profile
    {
        public RepositoryMappingProfile()
        {
            CreateMap<IUser, User>().ReverseMap();
            CreateMap<UserEntity, IUser>().As<User>();
            CreateMap<IUser, UserEntity>();
            CreateMap<UserEntity, User>().ReverseMap();
            CreateMap<PaginationList<IUser>, PaginationList<UserEntity>>().ReverseMap();

            CreateMap<IGroup, Group>().ReverseMap();
            CreateMap<GroupEntity, IGroup>().As<Group>();
            CreateMap<GroupEntity, Group>().ReverseMap();
        }
    }
}
