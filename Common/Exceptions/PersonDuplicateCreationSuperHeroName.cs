using Common.Enum;
using System.Net;

namespace Common.Exceptions
{
    public class PersonDuplicateCreationSuperHeroName : BusinessExceptionBase
    {
        public PersonDuplicateCreationSuperHeroName(string message) : base(message) 
        {
            ErrorCode = ErrorCodes.PersonDuplicateCreationSuperHeroName;
            StatusCode = HttpStatusCode.NotFound;
        }
    }
}
