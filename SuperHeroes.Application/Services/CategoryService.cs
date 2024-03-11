using Common.Exceptions;
using SuperHeroes.Application.Interfaces;
using SuperHeroes.Application.Models.Request;
using SuperHeroes.Application.Models.Response;
using SuperHeroes.Domain.Entities;

namespace SuperHeroes.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPersonRepository _personRepository;

        public CategoryService(ICategoryRepository categoryRepository, IPersonRepository personRepository)
        {
            _categoryRepository = categoryRepository;
            _personRepository = personRepository;
        }

        public async Task<List<Category>> GetAllCategory()
        {
            return await _categoryRepository.GetAllCategories();
        }

        public async Task<CategoryResponseModel> GetCategoryById(long id)
        {
            var isExist = await _categoryRepository.AnyCategoryById(id);
            if (!isExist)
            {
                throw new CategoryNotFoundException($"Category with this ID: {id} not found.");
            }
            var categoryById = await _categoryRepository.GetCategoryById(id);
            var categoryResponseModel = new CategoryResponseModel
            {
                Name = categoryById.Name,
                Persons = categoryById.CategoryPersons.Select(cp => new CategoryPersonResponseModel
                {
                    PersonId = cp.PersonId,
                    FirstName = cp.Person.FirstName,
                    LastName = cp.Person.LastName,
                    SuperHeroName = cp.Person.SuperHeroName,
                    Age = cp.Person.Age
                }).ToList()
            };
            return categoryResponseModel;
        }

        public async Task CreateCategory(CategoryRequestModel categoryRequestModel)
        {
            var isExist = await _categoryRepository.AnyCategoryWithName(categoryRequestModel.Name);
            if (isExist)
            {
                throw new CategoryDuplicateCreationName($"Person with this Superhero name - {categoryRequestModel.Name} already exist.");
            }
            await _categoryRepository.CreateCategory(new Category
            {
                Name = categoryRequestModel.Name
            });
        }

        public async Task AddPerson(long categoryId, long personId)
        {
            var isExistForCategoryId = await _categoryRepository.AnyCategoryById(categoryId);
            if (!isExistForCategoryId)
            {
                throw new CategoryNotFoundException($"Category with this ID: {categoryId} not found.");
            }
            var isExistForPersonId = await _personRepository.AnyPersonById(personId);
            if (!isExistForPersonId)
            {
                throw new PersonNotFoundException($"Person with this ID: {personId} not found.");
            }
            await _categoryRepository.AddPerson(categoryId, personId);
        }

        public async Task<CategoryResponseModel> UpdateCategory(int categoryId, CategoryUpdateRequestModel categoryUpdateRequestModel)
        {

            var isExist = await _categoryRepository.AnyCategoryById(categoryId);
            if (!isExist)
            {
                throw new CategoryNotFoundException($"Category with this ID: {categoryId} not found.");
            }

            var category = new Category 
            {
                Id = categoryId,
                Name = categoryUpdateRequestModel.Name 
            };
           
            await _categoryRepository.UpdateCategory(category);
            Category categoryResponseModel = await _categoryRepository.GetCategoryById(category.Id);
            return new CategoryResponseModel 
            {   
                Name = categoryResponseModel.Name 
            };
        }

        public async Task DeleteCategory(long categoryId)
        {
            var isExist = await _categoryRepository.AnyCategoryById(categoryId);
            if (!isExist)
            {
                throw new CategoryNotFoundException($"Category with this ID: {categoryId} not found.");
            }
            await _categoryRepository.DeleteCategoryById(categoryId);
        }
    }
}
