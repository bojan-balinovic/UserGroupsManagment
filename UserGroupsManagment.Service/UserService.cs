using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserGroupsManagment.Model;
using UserGroupsManagment.Model.Contractors;
using UserGroupsManagment.Model.Filters;
using UserGroupsManagment.Repository.Contractors;
using UserGroupsManagment.Service.Contractors;

namespace UserGroupsManagment.Service
{
    public class UserService : IUserService
    {
        public IUserRepository Repository { get; }

        public UserService(IUserRepository repository)
        {
            Repository = repository;
        }

      
        public async Task<IUser> AddOne(IUser model)
        {
            return await Repository.AddOne(model);   
        }

        public async Task<IUser> DeleteOne(Guid id)
        {
            return await Repository.DeleteOne(id);
        }

        public async Task<PaginationList<IUser>> GetMany(UserFilter filter, int currentPage = -1, string orderBy = "")
        {
            return await Repository.GetManyByFilter(filter, currentPage, orderBy);
        }

        public async Task<IUser> GetOne(Guid id)
        {
            return await Repository.GetOne(id);
        }

        public async Task<IUser> UpdateOne(IUser model)
        {
            return await Repository.UpdateOne(model);
        }
        public async Task<IEnumerable<IUser>> GetAll()
        {
            return await Repository.GetAll();
        }
    }
}
