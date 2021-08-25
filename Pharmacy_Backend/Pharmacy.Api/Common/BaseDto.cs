using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Pharmacy.Api.Common
{
    public class RequestBase
    {
        [DataMember]
        public int LoggedInUserId { get; set; }
    }

    public class ResponseBase
    {
        public string ResponseResult { get; set; }
        public string ResponseMsg { get; set; }
        public List<ErrorDetails> ErrorDetails { get; set; }
    }

    public class ErrorDetails
    {
        public string ErrorMsg { get; set; }
        public string ErrorCode { get; set; }
    }
}
