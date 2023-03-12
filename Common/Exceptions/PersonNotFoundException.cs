using Common.Enum;
using System.Net;

namespace Common.Exceptions
{
    public class PersonNotFoundException : BusinessExceptionBase
    {
        public PersonNotFoundException(string message) : base(message)
        {
            ErrorCode = ErrorCodes.PersonNotFound;
            StatusCode = HttpStatusCode.NotFound;
        }
    }
}
