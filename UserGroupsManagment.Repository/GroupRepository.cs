using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public class GroupRepository : GenericRepository<MainContext, GroupEntity, IGroup, Group, GroupFilter>, IGroupRepository
    {
        public GroupRepository(MainContext context, IMapper mapper) : base(context, context.Groups, mapper)
        {

        }
        public override async Task<IQueryable<GroupEntity>> HandleFiltering(GroupFilter filter)
        {
            return (await base.HandleFiltering(filter)).Include(e => e.Users);
        }
    }
}
