using System;
using System.Collections.Generic;
using System.Text;
using UserGroupsManagment.Model.Contractors;

namespace UserGroupsManagment.Model
{
    public class BaseModel : IBaseModel
    {
        public int Id { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
