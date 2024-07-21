using Microsoft.EntityFrameworkCore;

namespace CMH.Application.Models
{
    public class PagedList<T>
    {
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public List<T> Items { get; set; }
        public bool HasNext => Page * PageSize < TotalCount;
        public bool HasPrevious => Page > 1;

        private PagedList(List<T> items, int page, int pageSize, int totalCount)
        {
            Items = items;
            Page = page;
            PageSize = pageSize;
            TotalCount = totalCount;
        }
        public static async Task<PagedList<T>>  CreateAsync(IEnumerable<T> query, int page,int pageSize)
        {
            int totalCount =  query.Count();
            var items =  query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return new(items,page,pageSize,totalCount);
        }
    }
}
