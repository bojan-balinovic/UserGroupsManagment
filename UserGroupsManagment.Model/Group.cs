using System;
using System.Collections.Generic;
using System.Text;
using UserGroupsManagment.Model.Contractors;

namespace UserGroupsManagment.Model
{
    public class Group:BaseModel, IGroup
    {
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}
