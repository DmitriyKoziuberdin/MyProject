using SuperHeroes.Domain.Entities; 

namespace SuperHeroes.Application.Models.Request
{
    public class PersonModel
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string SuperHeroName { get; set; } = null!;
        public int Age { get; set; }
        //public ICollection<CategoryPerson> categoryPeople { get; set; } = null!;
    }
}
