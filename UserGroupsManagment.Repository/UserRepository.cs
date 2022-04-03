using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UserGroupsManagment.Entity;
using UserGroupsManagment.Model;
using UserGroupsManagment.Model.Contractors;
using UserGroupsManagment.Model.Filters;
using UserGroupsManagment.Repository.Contractors;

namespace UserGroupsManagment.Repository
{
    public class UserRepository : GenericRepository<MainContext, UserEntity, IUser, User, UserFilter>, IUserRepository
    {
        public UserRepository(MainContext context, IMapper mapper) : base(context, context.Users, mapper)
        {

        }

    }
}
