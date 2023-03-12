namespace SuperHeroes.Application.Models.Request
{
    public class CategoryUpdateRequestModel
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
