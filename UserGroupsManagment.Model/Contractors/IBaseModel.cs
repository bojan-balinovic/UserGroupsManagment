using System;
using System.Collections.Generic;
using System.Text;

namespace UserGroupsManagment.Model.Contractors
{
    public interface IBaseModel
    {
        public int Id { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
