using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserGroupsManagment.Model;
using UserGroupsManagment.Model.Contractors;

namespace UserGroupsManagment.ViewModels
{
    public class CreateGroupViewModel
    {
        public string Name { get; set; }
        public List<IUser> Users { get; set; }
    }
}
