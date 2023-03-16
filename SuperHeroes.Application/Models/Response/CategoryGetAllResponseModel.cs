using SuperHeroes.Domain.Entities;

namespace SuperHeroes.ApplicationServices.Models.Response
{
    public class CategoryGetAllResponseModel : BaseEntity
    {
        public long categoryId { get; set; }
        public string? categoryName { get; set; }
    }
}
