using Microsoft.Extensions.Caching.Memory;
using SuperHeroes.Application.Interfaces;
using SuperHeroes.Domain.Entities;

namespace SuperHeroes.Infrastructure.Repositories
{
    public class CachedCategoryRepository : ICategoryRepository
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly IMemoryCache _memoryCache;
        private static string _cacheKey = "category";

        public CachedCategoryRepository(CategoryRepository _categoryRepository, IMemoryCache _memoryCache)
        {
            this._categoryRepository = _categoryRepository;
            this._memoryCache = _memoryCache;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            var categories = await _memoryCache
                .GetOrCreateAsync(_cacheKey, (entry) => _categoryRepository.GetAllCategories());
            return categories!.ToList();
        }

        public async Task<Category> GetCategoryById(long id)
        {
            return await _categoryRepository.GetCategoryById(id);
        }

        public async Task AddPerson(long categoryId, long personId)
        {
            _memoryCache.Remove(_cacheKey);
            await _categoryRepository.AddPerson(categoryId, personId);
        }

        public async Task CreateCategory(Category category)
        {
            _memoryCache.Remove(_cacheKey);
            await _categoryRepository.CreateCategory(category); 
        }

        public async Task UpdateCategory(Category category)
        {
            _memoryCache.Remove(_cacheKey);
            await _categoryRepository.UpdateCategory(category);
        }

        public async Task<int> DeleteCategoryById(long id)
        {
            _memoryCache.Remove(_cacheKey);
            return await _categoryRepository.DeleteCategoryById(id);    
        }
    }
}
