using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public async override Task<IQueryable<UserEntity>> HandleFiltering(UserFilter filter)
        {
            var entities=await base.HandleFiltering(filter);
            if (string.IsNullOrEmpty(filter.Name) == false)
            {
                entities = entities.Where(e => e.Name == filter.Name);
            }
            if (filter.GroupId != null)
            {
                entities = entities.Where(e => e.GroupId == filter.GroupId);
            }
            return entities;
        }
    }
}
