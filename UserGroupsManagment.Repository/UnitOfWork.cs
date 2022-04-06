using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserGroupsManagment.Repository.Contractors;

namespace UserGroupsManagment.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private IUserRepository userRepository;
        public IUserRepository UserRepository => userRepository ?? new UserRepository(Context, Mapper);
        private IGroupRepository groupRepository;
        public IGroupRepository GroupRepository => groupRepository ?? new GroupRepository(Context, Mapper);
        public MainContext Context { get; }
        public IMapper Mapper { get; }

        public UnitOfWork(MainContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
        public async Task<bool> Complete() => await Context.SaveChangesAsync() > 0;

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
