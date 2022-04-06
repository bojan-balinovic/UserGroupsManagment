using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserGroupsManagment.Model;
using UserGroupsManagment.Model.Contractors;
using UserGroupsManagment.Model.Filters;
using UserGroupsManagment.Repository.Contractors;
using UserGroupsManagment.Service.Contractors;

namespace UserGroupsManagment.Service
{
    public class GroupService : IGroupService
    {
        public GroupService(IGroupRepository repository)
        {
            Repository = repository;
        }

        public IGroupRepository Repository { get; }

        public async Task<IGroup> AddOne(IGroup model)
        {
            return await Repository.AddOne(model);
        }

        public async Task<IGroup> DeleteOne(int id)
        {
            return await Repository.DeleteOne(id);
        }

        public async Task<PaginationList<IGroup>> GetMany(GroupFilter filter, int currentPage = -1, string orderBy = "")
        {
            return await Repository.GetManyByFilter(filter, currentPage, orderBy);
        }

        public async Task<IGroup> GetOne(int id)
        {
            return await Repository.GetOne(id);
        }

        public async Task<IGroup> UpdateOne(IGroup model)
        {
            return await Repository.UpdateOne(model);
        }
        public async Task<IEnumerable<IGroup>> GetAll()
        {
            return await Repository.GetAll();
        }

        public async Task<IGroup> GetOneByFilter(GroupFilter filter)
        {
            return await Repository.GetOneByFilter(filter);
        }
    }
}
