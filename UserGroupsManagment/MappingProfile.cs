using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserGroupsManagment.Model;
using UserGroupsManagment.Model.Contractors;
using UserGroupsManagment.ViewModels;

namespace UserGroupsManagment
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserViewModel, User>();
            CreateMap<CreateUserViewModel, IUser>().As<User>();
            CreateMap<CreateGroupViewModel, Group>();
            CreateMap<CreateGroupViewModel, IGroup>().As<Group>();

            CreateMap<Group, GroupViewModel>();
            CreateMap<IGroup, GroupViewModel>();
            CreateMap<User, UserViewModel>();
            CreateMap<IUser, UserViewModel>();

            //CreateMap<PaginationList<IGroup>, PaginationList<GroupViewModel>>().ForAllMembers(opt=>opt.Ignore()).ForMember(e=>e._items, opt => opt.MapFrom((src, dest) => {
            //    return src._items;
            //   });
            //CreateMap<PaginationList<IGroup>, PaginationList<GroupViewModel>>();
            //  CreateMap<PaginationList<IUser>, PaginationList<UserViewModel>>();

            CreateMap<EditGroupViewModel, Group>();
            CreateMap<EditGroupViewModel, IGroup>().As<Group>();
            CreateMap<EditUserViewModel, User>();
            CreateMap<EditUserViewModel, IUser>().As<User>();
        }
    }
}
