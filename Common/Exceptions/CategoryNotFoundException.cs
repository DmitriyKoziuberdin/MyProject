using Common.Enum;
using System.Net;

namespace Common.Exceptions
{
    public class CategoryNotFoundException : BusinessLogicExceptionBase
    {
        public CategoryNotFoundException(string message) : base(message) 
        {
            ErrorCode = ErrorCodes.CategoryNotFound;
            StatusCode = HttpStatusCode.NotFound;
        }
    }
}
