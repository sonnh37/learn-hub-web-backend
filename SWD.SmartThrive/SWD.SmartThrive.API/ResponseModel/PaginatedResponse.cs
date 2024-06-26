using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SWD.SmartThrive.API.ResponseModel
{
    public class PaginatedResponse<TResult> : BaseResponse where TResult : class
    {
        public TResult? Result { get; }

        public PaginatedResponse(string message, TResult? result = null ) : base(result!=null, message)
        {
            Result = result;
        }
    }

    public class PaginatedResponseList<TResult> : BaseResponse where TResult : class
    {
        public List<TResult>? Results { get; }

        public int TotalPages { get; protected set; }

        public int TotalRecordsPerPage { get; protected set; }

        public int TotalRecords { get; protected set; }

        public int PageNumber { get; protected set; }

        public int PageSize { get; protected set; }

        public string? OrderBy { get; protected set; }

        public PaginatedResponseList(string message, List<TResult>? results = null, long totalOrigin = 0, int pageNumber = 1, int pageSize = 1, string? orderBy = null) : base(results != null, message)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            OrderBy = orderBy;
            Results = results;
            TotalRecords = (int) totalOrigin;
            TotalRecordsPerPage = results != null ? results.Count : 0;
            TotalPages = (int)Math.Ceiling(totalOrigin / (double)PageSize);
        }
    }

    
}
