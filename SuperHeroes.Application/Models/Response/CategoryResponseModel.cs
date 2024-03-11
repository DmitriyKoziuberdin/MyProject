namespace SuperHeroes.Application.Models.Response
{
    public class CategoryResponseModel
    {
        public string Name { get; set; } = null!; 
        public List<CategoryPersonResponseModel>? Persons { get; set; }
    }
}
