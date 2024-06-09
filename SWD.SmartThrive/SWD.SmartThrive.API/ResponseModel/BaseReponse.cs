using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SWD.SmartThrive.API.ResponseModel
{

    public abstract class BaseReponse
    {
        public int Code { get; protected set; }
        public long TotalRecords { get; protected set; }
        public bool IsSuccess { get; protected set; }
        public string Message { get; protected set; }
    }

    public class BaseReponse<TResult> : BaseReponse where TResult : class
    {
        public TResult Result { get; }

        public BaseReponse(TResult result, string message, int code)
        {
            Code = code;
            Result = result;
            TotalRecords = result != null ? 1 : 0;
            IsSuccess = result != null;
            Message = message;
        }
    }
    
    public class BaseReponseBool
    {
        public bool IsData { get; protected set; }
        public int Code { get; protected set; }
        public string Message { get; protected set; }

        public BaseReponseBool(bool isData, string message, int code)
        {
            Code = code;
            IsData = isData;
            Message = message;
        }
    }

    public class BaseReponseList<TResult> : BaseReponse where TResult : class
    {
        public IList<TResult> Results { get; }


        public BaseReponseList(IList<TResult> results, string message, int code)
        {
            Code = code;
            Results = results;
            TotalRecords = results != null ? results.Count : 0;
            IsSuccess = results != null;
            Message = message;
        }
    }

    public class LoginResponse<TResult> : BaseReponse where TResult : class
    {
        public TResult Result { get; }
        public string Token { get; }
        public string Expiration { get; }
        public string message { get; }

        public LoginResponse(TResult result, string token, string expiration, string message, int code)
        {
            Code = code;
            Result = result;
            Token = token;
            Expiration = expiration;
            TotalRecords = result != null ? 1 : 0;
            IsSuccess = result != null;
            Message = message;
        }
    }
}
