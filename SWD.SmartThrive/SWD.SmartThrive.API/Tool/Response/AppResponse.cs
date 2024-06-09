using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Common;
using SWD.SmartThrive.API.ResponseModel;
using SWD.SmartThrive.API.Tool.Constant;
using System.Reflection;

namespace SWD.SmartThrive.API.Tool.Response
{
    public class AppResponse
    {
        public static BaseReponseList<TResult> GetResponseResultList<TResult>(List<TResult> results, string message, int code = ConstantHttpStatus.OK)
            where TResult : class
        => new BaseReponseList<TResult>(results, message, code);

        public static BaseReponse<TResult> GetResponseResult<TResult>(TResult result, string message, int code = ConstantHttpStatus.OK)
            where TResult : class
        => new BaseReponse<TResult>(result, message, code);
        
        public static BaseReponseBool GetResponseBool(bool isData, string message, int code = ConstantHttpStatus.OK)
        => new BaseReponseBool(isData, message, code);

        public static LoginResponse<TResult> GetResponseLoginResult<TResult>(TResult result, string token, string expiration, string message, int code = ConstantHttpStatus.OK)
            where TResult : class
        => new LoginResponse<TResult>(result, token, expiration, message, code);
    }
}
