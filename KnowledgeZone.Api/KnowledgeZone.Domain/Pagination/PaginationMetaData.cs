namespace KnowledgeZone.Domain.Pagination
{
    public class PaginationMetaData
    {
        public int Totalcount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
