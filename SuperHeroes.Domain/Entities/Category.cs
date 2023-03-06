namespace SuperHeroes.Domain.Entities
{
    public class Category : BaseEntity
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!; //Marvel or DC
        public ICollection<CategoryPerson> CategoryPersons { get; set; } = null!; //All heroes Marvel or DC
    }
}
