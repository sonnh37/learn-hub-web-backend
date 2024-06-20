using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SWD.SmartThrive.API.ResponseModel
{

    public abstract class PaginatedResponse
    {
        public int TotalRecords { get; protected set; }

        public bool IsSuccess { get; protected set; }

        public string Message { get; protected set; }
    }

    public class PaginatedResponse<TResult> : PaginatedResponse where TResult : class
    {
        public TResult? Result { get; }

        public PaginatedResponse(string message, TResult? result = null )
        {
            Result = result;
            TotalRecords = result != null ? 1 : 0;
            IsSuccess = result != null;
            Message = message;
        }
    }

    public class PaginatedResponseList<TResult> : PaginatedResponse where TResult : class
    {
        public List<TResult>? Results { get; }

        public int TotalPages { get; protected set; }

        public int PageNumber { get; protected set; }

        public int PageSize { get; protected set; }

        public string? OrderBy { get; protected set; }

        public PaginatedResponseList(string message, List<TResult>? results = null, long totalOrigin = 0, int pageNumber = 1, int pageSize = 1, string? orderBy = null)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            OrderBy = orderBy;
            Results = results;
            TotalRecords = results != null ? results.Count : 0;
            TotalPages = (int)Math.Ceiling(totalOrigin / (double)PageSize);
            IsSuccess = results != null;
            Message = message;
        }
    }

    public class BaseReponseBool
    {
        public bool IsData { get; protected set; }
        public string Message { get; protected set; }

        public BaseReponseBool(bool isData, string message)
        {
            IsData = isData;
            Message = message;
        }
    }

    public class LoginResponse<TResult> : PaginatedResponse where TResult : class
    {
        public TResult Result { get; }
        public string Token { get; }
        public string Expiration { get; }

        public LoginResponse(TResult result, string token, string expiration, string message)
        {
            Result = result;
            Token = token;
            Expiration = expiration;
            TotalRecords = result != null ? 1 : 0;
            IsSuccess = result != null;
            Message = message;
        }
    }
}
