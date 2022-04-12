using System;
using System.Collections.Generic;
using System.Text;

namespace UserGroupsManagment.Model.Filters
{
    public class UserFilter:GenericFilter
    {
        public string? Name { get; set; }
        public int? GroupId { get; set; }
    }
}
