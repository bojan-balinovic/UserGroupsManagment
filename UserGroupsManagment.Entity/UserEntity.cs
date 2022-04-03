using System;

namespace UserGroupsManagment.Entity
{
    public class UserEntity:BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }
}
