using System;
using System.Collections.Generic;
using System.Text;

namespace UserGroupsManagment.Model.Filters
{
    public abstract class GenericFilter
    {
        public virtual Guid? Id { get; set; }
        public Guid? UserId { get; set; }
        public int? CurrentPage { get; set; }
        public int? PageSize { get; set; }
        public string OrderBy { get; set; }
    }
}
