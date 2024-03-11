namespace SuperHeroes.ApplicationServices.Models.Response
{
    public class PersonUpdateResponseModel
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string SuperHeroName { get; set; } = null!;
        public int Age { get; set; }
    }
}
