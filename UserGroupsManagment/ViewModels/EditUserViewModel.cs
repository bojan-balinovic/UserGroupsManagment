using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserGroupsManagment.ViewModels
{
    public class EditUserViewModel
    {
        public int Id { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [MinLength(8)]
        public string Password { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
    }
}
