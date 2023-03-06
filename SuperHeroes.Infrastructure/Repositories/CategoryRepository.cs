using Microsoft.EntityFrameworkCore;
using SuperHeroes.Application.Interfaces;
using SuperHeroes.Application.Models.Response;
using SuperHeroes.Domain;
using SuperHeroes.Domain.Entities;

namespace SuperHeroes.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext _appDbContext;

        public CategoryRepository(ApplicationDBContext _appDbContext)
        {
            this._appDbContext = _appDbContext;
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
            //var response = new CategoryResponse
            //{
            //    Id = getCategory.Id,
            //    Name = getCategory.Name,
            //    Persons = getCategory.CategoryPersons.Select(cp => new CategoryPersonResponse
            //    {
            //        PersonId = cp.PersonId,
            //        FirstName = cp.Person.FirstName,
            //        LastName = cp.Person.LastName,
            //        SuperHeroName = cp.Person.SuperHeroName,
            //        Age = cp.Person.Age
            //    }).ToList()
            //};
            return getCategory;
        }

        public async Task CreateCategory(Category category)
        {
            await _appDbContext.AddAsync(category);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task AddPerson(long categoryId, long personId)
        {
            if (!await _appDbContext.Categories.AnyAsync(id => id.Id == categoryId))
                throw new Exception("Not Found");
            if (!await _appDbContext.Person.AnyAsync(id => id.Id == personId))
                throw new Exception("Not Found");
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
            var deleteCategory = await _appDbContext.Categories.Where(categoryId=>categoryId.Id == id).ExecuteDeleteAsync();
            await _appDbContext.SaveChangesAsync();
            return deleteCategory;
        }
    }
}
