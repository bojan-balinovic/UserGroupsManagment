using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserGroupsManagment.Model;
using UserGroupsManagment.Model.Contractors;
using UserGroupsManagment.Model.Filters;

namespace UserGroupsManagment.Service.Contractors
{
    public interface IGroupService : IGenericService<IGroup, GroupFilter>
    {
    }
}
