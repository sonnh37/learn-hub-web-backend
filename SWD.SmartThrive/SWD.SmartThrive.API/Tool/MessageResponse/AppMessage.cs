using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Common;
using SWD.SmartThrive.API.ResponseModel;
using System.Reflection;

namespace Smart_Thrive.Tool.MessageResponse
{
    public class AppMessage
    {
        public static BaseReponseList<TResult> GetMessageResults<TResult>(List<TResult> results)

            where TResult : class
        {
            return new BaseReponseList<TResult>(results);
        }

        public static BaseReponse<TResult> GetMessageResult<TResult>(TResult result)
            where TResult : class
        {
            return new BaseReponse<TResult>(result);
        }

        public static LoginResponse<TResult> GetMessageLoginResult<TResult>(TResult result, string token, string expiration)
            where TResult : class
        {
            return new LoginResponse<TResult>(result, token, expiration);
        }
    }
}
