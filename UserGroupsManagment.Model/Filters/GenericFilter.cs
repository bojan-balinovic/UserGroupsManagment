using System;
using System.Collections.Generic;
using System.Text;

namespace UserGroupsManagment.Model.Filters
{
    public abstract class GenericFilter
    {
        public virtual int? Id { get; set; }
        public int? CurrentPage { get; set; } = 1;
        public int? PageSize { get; set; }
        public string OrderBy { get; set; }
    }
}
