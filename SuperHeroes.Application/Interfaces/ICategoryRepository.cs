using SuperHeroes.Application.Models.Request;
using SuperHeroes.Domain.Entities;

namespace SuperHeroes.Application.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> GetAllCategories();
        public Task<Category> GetCategoryById(long id);
        public Task CreateCategory(Category category);
        public Task AddPerson(long categoryId, long personId);
        public Task UpdateCategory(Category category);
        public Task<int> DeleteCategoryById(long id);
    }
}
