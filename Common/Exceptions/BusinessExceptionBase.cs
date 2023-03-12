using Common.Enum;
using System.Net;

namespace Common.Exceptions
{
    public class BusinessExceptionBase : Exception
    {
        public ErrorCodes ErrorCode { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public BusinessExceptionBase(string message) : base(message)
        {

        }
    }
}
