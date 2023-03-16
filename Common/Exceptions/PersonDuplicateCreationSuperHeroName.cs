using Common.Enum;
using System.Net;

namespace Common.Exceptions
{
    public class PersonDuplicateCreationSuperHeroName : BusinessLogicExceptionBase
    {
        public PersonDuplicateCreationSuperHeroName(string message) : base(message) 
        {
            ErrorCode = ErrorCodes.PersonDuplicateCreationSuperHeroName;
            StatusCode = HttpStatusCode.NotFound;
        }
    }
}
