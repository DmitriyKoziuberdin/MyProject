using Microsoft.EntityFrameworkCore;
using SuperHeroes.Application.Interfaces;
using SuperHeroes.Domain;
using SuperHeroes.Domain.Entities;

namespace SuperHeroes.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext _appDbContext;

        public CategoryRepository(ApplicationDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _appDbContext.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(long id)
        {
            var getCategory = await _appDbContext.Categories
                .Include(categoryPeople=> categoryPeople.CategoryPersons)
                .ThenInclude(person => person.Person)
                .FirstAsync(categoryId => categoryId.Id == id);
            return getCategory;
        }

        public async Task<bool> AnyCategoryById(long categoryId)
        {
            return await _appDbContext.Categories.AnyAsync(id => id.Id == categoryId);
        }

        public async Task CreateCategory(Category category)
        {
            await _appDbContext.AddAsync(category);
            await _appDbContext.SaveChangesAsync();
        }

        public Task<bool> AnyCategoryWithName(string categoryName)
        {
            return _appDbContext.Categories.AnyAsync(name => name.Name == categoryName);
        }

        public async Task AddPerson(long categoryId, long personId)
        {
            _appDbContext.Set<CategoryPerson>().Add(new CategoryPerson
            {
                CategoryId = categoryId,
                PersonId = personId
            });
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateCategory(Category category)
        {
            _appDbContext.Categories.Update(category);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteCategoryById(long id)
        {
            var deleteCategory = await _appDbContext.Categories
                .Where(categoryId=>categoryId.Id == id)
                .ExecuteDeleteAsync();
            await _appDbContext.SaveChangesAsync();
            return deleteCategory;
        }
    }
}
