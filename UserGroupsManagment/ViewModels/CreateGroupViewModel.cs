using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UserGroupsManagment.Model;
using UserGroupsManagment.Model.Contractors;

namespace UserGroupsManagment.ViewModels
{
    public class CreateGroupViewModel
    {
        [Required]
        public string Name { get; set; }
        public List<CreateUserViewModel> Users { get; set; }
    }
}
