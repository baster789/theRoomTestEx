using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Utils;

namespace WebApi.Models.Response
{
    public class PaginatedResponse<T>
    {
        private readonly PaginatedList<T> _items;
        public IEnumerable<T> Items { get => _items; }
        public int PageIndex { get => _items.PageIndex; }
        public int PageSize { get => _items.PageSize; }
        public int TotalPages { get => _items.TotalPages; }
        public int ItemIndex { get => _items.ItemIndex; }
        public int ItemsLeft { get => _items.ItemsLeft; }
        public int TotalItems { get => _items.TotalItems; }
        public bool HasPreviousPage { get => _items.HasPreviousPage; }
        public bool HasNextPage { get => _items.HasNextPage; }
        public PaginatedResponse(PaginatedList<T> items)
        {
            _items = items;
        }
    }
}
