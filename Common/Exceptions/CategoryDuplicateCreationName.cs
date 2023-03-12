using Common.Enum;
using System.Net;

namespace Common.Exceptions
{
    public class CategoryDuplicateCreationName : BusinessExceptionBase
    {
        CategoryDuplicateCreationName(string message) : base(message)
        {
            ErrorCode = ErrorCodes.CategoryDuplicationCreationName;
            StatusCode = HttpStatusCode.NotFound;
        }
    }
}
