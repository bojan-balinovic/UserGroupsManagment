using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserGroupsManagment.Entity
{
    public class UserEntity:BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int? GroupId { get; set; }
        [ForeignKey("GroupId")]
        public GroupEntity Group { get; set; }
    }
}
