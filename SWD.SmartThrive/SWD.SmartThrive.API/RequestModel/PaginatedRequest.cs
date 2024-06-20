namespace SWD.SmartThrive.API.RequestModel
{
    public class PaginatedRequest
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? OrderBy { get; set; }

        public PaginatedRequest(int pageNumber, int pageSize, string? orderBy)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            OrderBy = orderBy;
        }
    }

    public class PaginatedRequest<T> : PaginatedRequest where T : class
    {
        public T? Result { get; set; }

        public PaginatedRequest(T? Result, int pageNumber, int pageSize, string? orderBy) : base(pageNumber, pageSize, orderBy)
        {
            this.Result = Result;
        }
    }
}
