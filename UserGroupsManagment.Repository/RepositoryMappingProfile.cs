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
            CreateMap<IUser, UserEntity>();
            CreateMap<UserEntity, IUser>().As<User>();
            CreateMap<UserEntity, User>().ReverseMap();
            CreateMap<PaginationList<IUser>, PaginationList<UserEntity>>().ReverseMap();

            CreateMap<IGroup, Group>().ReverseMap();
            CreateMap<IGroup, GroupEntity>().ReverseMap();
            CreateMap<GroupEntity, IGroup>().As<Group>();
            CreateMap<GroupEntity, Group>().ReverseMap();
            CreateMap<PaginationList<IGroup>, PaginationList<GroupEntity>>().ReverseMap();

        }
    }
}
