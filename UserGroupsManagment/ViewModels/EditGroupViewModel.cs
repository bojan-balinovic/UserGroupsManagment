using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserGroupsManagment.ViewModels
{
    public class EditGroupViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<EditUserViewModel> Users { get; set; }
    }
}
