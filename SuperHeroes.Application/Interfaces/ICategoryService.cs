using SuperHeroes.Application.Models.Request;
using SuperHeroes.Application.Models.Response;
using SuperHeroes.ApplicationServices.Models.Response;
using SuperHeroes.Domain.Entities;

namespace SuperHeroes.Application.Interfaces
{
    public interface ICategoryService
    {
        public Task<List<Category>> GetAllCategory();
        public Task<CategoryResponseModel> GetCategoryById(long id);
        public Task CreateCategory(CategoryRequestModel categoryModel);
        public Task AddPerson(long categoryId, long productId);
        public Task<CategoryResponseModel> UpdateCategory(CategoryUpdateRequestModel categoryUpdateModel);
        public Task DeleteCategory(long categoryId);
    }
}
