using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SWD.SmartThrive.API.ResponseModel
{

    public abstract class BaseReponse
    {
        public int Code { get; set; }
        public long TotalRecords { get; protected set; }
        public bool IsSuccess { get; protected set; }
    }

    public class BaseReponse<TResult> : BaseReponse where TResult : class
    {
        public TResult Result { get; }

        public BaseReponse(TResult result)
        {
            Result = result;
            TotalRecords = result != null ? 1 : 0;
            IsSuccess = result != null;
        }
    }

    public class BaseReponseList<TResult> : BaseReponse where TResult : class
    {
        public IList<TResult> Results { get; }

        public BaseReponseList(IList<TResult> results)
        {
            Results = results;
            TotalRecords = results?.Count ?? 0;
            IsSuccess = results != null;
        }
    }

    public class LoginResponse<TResult> : BaseReponse where TResult : class
    {
        public TResult Result { get; }
        public string Token { get; }
        public string Expiration { get; }

        public LoginResponse(TResult result, string token, string expiration)
        {
            Result = result;
            Token = token;
            Expiration = expiration;
            TotalRecords = result != null ? 1 : 0;
            IsSuccess = result != null;
        }
    }
}
