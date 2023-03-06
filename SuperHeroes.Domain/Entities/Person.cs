namespace SuperHeroes.Domain.Entities
{
    public class Person : BaseEntity
    {
        public long Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string SuperHeroName { get; set; } = null!;
        public int Age { get; set; }
        public ICollection<CategoryPerson> CategoryPersons { get; set; } = null!;
    }
}
