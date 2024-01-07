using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeZone.Domain.Pagination
{
    public class PaginatedList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool PreviosPage => CurrentPage > 1;
        public bool NextPage => CurrentPage < TotalPage;
        public PaginatedList(List<T> list, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPage = (int)Math.Ceiling(count / (double)pageSize);

            AddRange(list);
        }
    }
}
