namespace SWD.SmartThrive.API.RequestModel
{
    public class PaginatedRequest<T> where T : class
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? OrderBy { get; set; }

        public T? Result { get; set; }

        //public int TotalCount { get; set; }
        //public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);

        public PaginatedRequest(T? Result, int pageNumber, int pageSize, string? orderBy)
        {
            this.Result = Result;
            PageNumber = pageNumber;
            PageSize = pageSize;
            OrderBy = orderBy;
        }
    }
}
