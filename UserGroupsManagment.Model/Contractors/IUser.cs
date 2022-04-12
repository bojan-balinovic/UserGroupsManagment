using System;
using System.Collections.Generic;
using System.Text;

namespace UserGroupsManagment.Model.Contractors
{
    public interface IUser:IBaseModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int? GroupId { get; set; }
        public Group Group { get; set; }
    }
}
