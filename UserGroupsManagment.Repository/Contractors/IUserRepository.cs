using System;
using System.Collections.Generic;
using System.Text;
using UserGroupsManagment.Entity;
using UserGroupsManagment.Model;
using UserGroupsManagment.Model.Contractors;
using UserGroupsManagment.Model.Filters;

namespace UserGroupsManagment.Repository.Contractors
{
    public interface IUserRepository: IGenericRepository<MainContext, UserEntity,IUser, User, UserFilter>
    {
    }
}
