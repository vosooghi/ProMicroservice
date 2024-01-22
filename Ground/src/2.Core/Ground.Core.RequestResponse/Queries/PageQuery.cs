namespace Ground.Core.RequestResponse.Queries
{
    /// <summary>
    /// An implementation of IPageQuery
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    public class PageQuery<TData> : IPageQuery<TData>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public bool NeedTotalCount { get; set; }
        public string SortBy { get; set; }
        public bool SortAscending { get; set; }
    }
}
