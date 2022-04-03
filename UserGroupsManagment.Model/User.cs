using System;
using UserGroupsManagment.Model.Contractors;

namespace UserGroupsManagment.Model
{
    public class User:BaseModel, IUser
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }
}
