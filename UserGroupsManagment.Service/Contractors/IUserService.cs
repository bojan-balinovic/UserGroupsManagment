using System;
using System.Collections.Generic;
using System.Text;
using UserGroupsManagment.Model.Contractors;
using UserGroupsManagment.Model.Filters;

namespace UserGroupsManagment.Service.Contractors
{
    public interface IUserService:IGenericService<IUser, UserFilter>
    {
    }
}
