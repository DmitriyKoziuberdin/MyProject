namespace SuperHeroes.Application.Models.Response
{
    public class PersonResponseModel
    {
        public long PersonId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string SuperHeroName { get; set; } = null!;
        public int Age { get; set; }
    }
}
