namespace SuperHeroes.Application.Models.Response
{
    public class CategoryResponseModel
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!; 
        public List<CategoryPersonResponseModel>? Persons { get; set; }
    }
}
