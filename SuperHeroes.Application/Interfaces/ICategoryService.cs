using SuperHeroes.Application.Models.Request;
using SuperHeroes.Application.Models.Response;
using SuperHeroes.Domain.Entities;

namespace SuperHeroes.Application.Interfaces
{
    public interface ICategoryService
    {
        public Task<List<Category>> GetAllCategory();
        public Task<CategoryResponse> GetCategoryById(long id);
        public Task CreateCategory(CategoryModel categoryModel);
        public Task AddPerson(long categoryId, long productId);
        public Task<CategoryResponse> UpdateCategory(CategoryUpdateModel categoryUpdateModel);
        public Task DeleteCategory(long id);
    }
}
