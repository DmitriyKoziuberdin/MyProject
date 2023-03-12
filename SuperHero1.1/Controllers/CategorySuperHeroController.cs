using Microsoft.AspNetCore.Mvc;
using SuperHeroes.Application.Interfaces;
using SuperHeroes.Application.Models.Request;
using SuperHeroes.Application.Models.Response;
using SuperHeroes.Domain.Entities;

namespace SuperHero1._1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategorySuperHeroController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategorySuperHeroController(ICategoryService _categoryService)
        {
            this._categoryService= _categoryService;
        }

        [HttpGet]
        public async Task<List<Category>> GetAllCategory()
        {
            return await _categoryService.GetAllCategory();
        }

        [HttpGet("{id:long}")]
        public async Task<CategoryResponseModel> GetCategoryById([FromRoute] long id)
        {
            return await _categoryService.GetCategoryById(id);
        }

        [HttpPost]
        [Route("createCategory")]
        public async Task CreateCategory(CategoryRequestModel categoryModel)
        {
            await _categoryService.CreateCategory(categoryModel);
        }

        [HttpPost("{categoryId:long}/person/{personId:long}")]
        public async Task AddPerson([FromRoute] long categoryId, [FromRoute] long personId)
        {
            await _categoryService.AddPerson(categoryId, personId);
        }

        [HttpPut]
        [Route("updateCategory")]
        public async Task<CategoryResponseModel> UpdateCategory(CategoryUpdateRequestModel categoryUpdateModel)
        {
            return await _categoryService.UpdateCategory(categoryUpdateModel);
        }

        [HttpDelete("{categoryId:long}")]
        public async Task DeleteCategory([FromRoute] long categoryId)
        {
            await _categoryService.DeleteCategory(categoryId);
        }
    }
}
