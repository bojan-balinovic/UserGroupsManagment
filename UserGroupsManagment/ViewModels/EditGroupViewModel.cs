using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserGroupsManagment.Model;

namespace UserGroupsManagment.ViewModels
{
    public class EditGroupViewModel
    {
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}
