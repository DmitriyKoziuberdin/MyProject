using Common.Enum;
using System.Net;

namespace Common.Exceptions
{
    public class CategoryDuplicateCreationName : BusinessLogicExceptionBase
    {
        public CategoryDuplicateCreationName(string message) : base(message)
        {
            ErrorCode = ErrorCodes.CategoryDuplicateName;
            StatusCode = HttpStatusCode.NotFound;
        }
    }
}
