using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserGroupsManagment.Model;

namespace UserGroupsManagment.Service.Contractors
{
    public interface IGenericService<T, Filter>
    {
        Task<T> AddOne(T model);

        Task<T> DeleteOne(Guid id);

        Task<PaginationList<T>> GetMany(Filter filter, int currentPage = -1, string orderBy = "");

        Task<T> GetOne(Guid id);

        Task<T> UpdateOne(T model);
        Task<IEnumerable<T>> GetAll();
    }
}
