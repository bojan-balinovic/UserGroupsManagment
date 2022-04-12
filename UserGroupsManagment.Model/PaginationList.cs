using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserGroupsManagment.Model
{
    public class PaginationList<T>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        private IEnumerable<T> _items;
        private IMapper Mapper { get; }


        public PaginationList(IEnumerable<T> items, int currentPage, int? pageSize, IMapper mapper=null)
        {
            Items = items;
            CurrentPage = currentPage;
            Mapper = mapper;
            if (pageSize != null)
            {
                PageSize = (int)pageSize;
            }
            else
            {
                PageSize = 5;
            }
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
        public  PaginationList<TMap> GetMapped<TMap>()
        {
            if (Mapper == null) return null;
            var mappedItems = Mapper.Map<IEnumerable<T>, IEnumerable<TMap>>(_items);
            return new PaginationList<TMap>(mappedItems, CurrentPage, PageSize);
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
