using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserGroupsManagment.Model;
using UserGroupsManagment.Model.Filters;

namespace UserGroupsManagment.Repository.Contractors
{
    public interface IGenericRepository<TContext, Entity, IModel, Model, Filter> where Filter:GenericFilter
    {
        Task<IModel> AddOne(IModel model);

        Task<IModel> DeleteOne(Guid id);

        Task<PaginationList<IModel>> GetManyByFilter(Filter filter, int currentPage = -1, string orderBy = "");

        Task<IModel> GetOne(Guid id);

        Task<IModel> UpdateOne(IModel model);
        Task<IModel> GetOneByFilter(Filter filter);
        Task<IEnumerable<IModel>> GetAll(Filter filter=null, int currentPage = -1, string orderBy = "");
        Task<IQueryable<Entity>> HandleFiltering(Filter filter);

        IQueryable<Entity> HandleSorting(IQueryable<Entity> entities, string orderBy);
    }
}
