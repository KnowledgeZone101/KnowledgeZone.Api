namespace KnowledgeZone.Domain.ResourceParameters
{
    public class QualificationResourceParamentrs
    {
        private const int _maxPageSize = 50;
        public string? SearchString { get; set; }
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 15;
        public int PageSize
        {
            get => _pageSize;
            set
            {
                if (value >= _maxPageSize)
                {
                    value = _maxPageSize;
                }
                else
                {
                    value -= _pageSize;
                }
            }
        }
        public string? OrderBy { get; set; }
    }
}
