namespace SuperHeroes.Domain.Entities
{
    public class CategoryPerson : BaseEntity
    {
        public long CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public long PersonId { get; set; }
        public Person Person { get; set; } = null!;

    }
}
