using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserGroupsManagment.Model
{
    public class PaginationList<T>
    {
        private IEnumerable<T> _items;
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }

        public PaginationList(IEnumerable<T> items, int currentPage, int pageSize = 5)
        {
            Items = items;
            CurrentPage = currentPage;
            PageSize = pageSize;
        }

        public IEnumerable<T> Items
        {
            get
            {
                if (CurrentPage == -1)
                {
                    return _items;
                }
                return _items.Skip((CurrentPage - 1) * PageSize).Take(PageSize);
            }
            set
            {
                _items = value;
            }
        }

        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling(decimal.Divide(_items.Count(), PageSize));
            }
        }
    }
}
