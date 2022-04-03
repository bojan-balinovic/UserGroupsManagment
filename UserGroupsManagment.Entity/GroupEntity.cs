using System;
using System.Collections.Generic;
using System.Text;

namespace UserGroupsManagment.Entity
{
    public class GroupEntity:BaseEntity
    {
        public string Name { get; set; }
        public List<UserEntity> Users { get; set; }
    }
}
