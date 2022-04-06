using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UserGroupsManagment.Repository.Contractors
{
    public interface IUnitOfWork:IDisposable
    {
        public IUserRepository UserRepository { get; }
        public IGroupRepository GroupRepository { get; }
        Task<bool> Complete();

    }
}
