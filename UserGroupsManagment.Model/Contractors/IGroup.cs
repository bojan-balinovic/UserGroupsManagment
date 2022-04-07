using System;
using System.Collections.Generic;
using System.Text;

namespace UserGroupsManagment.Model.Contractors
{
    public interface IGroup:IBaseModel
    {
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}
