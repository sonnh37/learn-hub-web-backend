namespace SWD.SmartThrive.API.ResponseModel
{
    public class BaseResponse
    {
        public bool IsSuccess { get; protected set; }
        public string Message { get; protected set; }

        public BaseResponse(bool isData, string message)
        {
            IsSuccess = isData;
            Message = message;
        }
    }

    public class LoginResponse<TResult> : BaseResponse where TResult : class
    {
        public TResult Result { get; }
        public string Token { get; }
        public string Expiration { get; }

        public LoginResponse(string message, TResult result, string token, string expiration) : base(result != null, message)
        {
            Result = result;
            Token = token;
            Expiration = expiration;
        }
    }
}
