using SuperHeroes.Domain.Entities; 

namespace SuperHeroes.Application.Models.Request
{
    public class PersonRequestModel
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string SuperHeroName { get; set; } = null!;
        public int Age { get; set; }
    }
}
