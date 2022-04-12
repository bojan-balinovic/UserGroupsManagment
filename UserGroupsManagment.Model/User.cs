using System;
using System.ComponentModel.DataAnnotations;
using UserGroupsManagment.Model.Contractors;

namespace UserGroupsManagment.Model
{
    public class User:BaseModel, IUser
    {
        [EmailAddress]
        public string Email { get; set; }
        [MinLength(8)]
        public string Password { get; set; }
        public string Name { get; set; }
        public int? GroupId { get; set; }
        public Group Group { get; set; }
    }
}
