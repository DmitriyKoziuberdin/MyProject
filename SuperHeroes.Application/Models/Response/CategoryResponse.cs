namespace SuperHeroes.Application.Models.Response
{
    public class CategoryResponse
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!; 
        public List<CategoryPersonResponse>? Persons { get; set; }
    }
}
