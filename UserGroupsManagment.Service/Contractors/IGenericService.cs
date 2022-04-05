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

        Task<T> DeleteOne(int id);

        Task<PaginationList<T>> GetMany(Filter filter, int currentPage = -1, string orderBy = "");

        Task<T> GetOne(int id);

        Task<T> UpdateOne(T model);
        Task<IEnumerable<T>> GetAll();
    }
}
