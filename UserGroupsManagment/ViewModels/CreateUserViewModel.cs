using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserGroupsManagment.ViewModels
{
    public class CreateUserViewModel
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [MinLength(8)]
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        public int? GroupId { get; set; }
    }
}
