
using SuperHeroes.Application.Interfaces;
using SuperHeroes.Application.Models.Request;
using SuperHeroes.Application.Models.Response;
using SuperHeroes.Domain.Entities;

namespace SuperHeroes.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository _categoryRepository)
        {
            this._categoryRepository = _categoryRepository;
        }

        public async Task<List<Category>> GetAllCategory()
        {
            return await _categoryRepository.GetAllCategories();
        }

        public async Task<CategoryResponse> GetCategoryById(long id)
        {
            var categoryById = await _categoryRepository.GetCategoryById(id);
            var response = new CategoryResponse
            {
                Id = categoryById.Id,
                Name = categoryById.Name,
                Persons = categoryById.CategoryPersons.Select(cp => new CategoryPersonResponse
                {
                    PersonId = cp.PersonId,
                    FirstName = cp.Person.FirstName,
                    LastName = cp.Person.LastName,
                    SuperHeroName = cp.Person.SuperHeroName,
                    Age = cp.Person.Age
                }).ToList()
            };
            return response;
        }

        public async Task CreateCategory(CategoryModel categoryModel)
        {
            await _categoryRepository.CreateCategory(new Category
            {
                Name = categoryModel.Name
            });
        }

        public async Task AddPerson(long categoryId, long personId)
        {
            await _categoryRepository.AddPerson(categoryId, personId);
        }

        public async Task<CategoryResponse> UpdateCategory(CategoryUpdateModel categoryUpdateModel)
        {
            var category = new Category 
            {
                Id = categoryUpdateModel.Id,
                Name = categoryUpdateModel.Name 
            };
            await _categoryRepository.UpdateCategory(category);
            Category categoryResponse = await _categoryRepository.GetCategoryById(category.Id);
            return new CategoryResponse 
            {   
                Id = categoryResponse.Id,
                Name = categoryResponse.Name 
            };
        }

        public async Task DeleteCategory(long id)
        {
            var deleteCategory = _categoryRepository.DeleteCategoryById(id);
            if(deleteCategory == null)
            {
                throw new Exception("Empty");
            }
            await deleteCategory;
        }
    }
}
