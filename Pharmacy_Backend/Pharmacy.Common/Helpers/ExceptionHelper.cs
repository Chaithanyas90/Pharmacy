using Pharmacy.Api.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pharmacy.Common.Helpers
{
    public class ExceptionHelper
    {
        public static T ProcessException<T>( RequestBase Request, Exception ex) where T : ResponseBase
        {
            var _Response = Activator.CreateInstance<T>();
            var _UserId = Request.LoggedInUserId;

            if (ex is ValidationException)
                _Response.ResponseResult = ResponseResult.ResponseResultEnum.Warning.ToString();
            else
                _Response.ResponseResult = ResponseResult.ResponseResultEnum.ServiceFault.ToString();

            var _errMsg = "ANY MESSAGE";

            _Response.ResponseMsg = _errMsg;

            return _Response;
        }

    }
}
