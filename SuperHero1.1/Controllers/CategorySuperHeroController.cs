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
        [Route("categories")]
        public async Task<List<Category>> GetAllCategory()
        {
            return await _categoryService.GetAllCategory();
        }

        [HttpGet]
        [Route("{id:long}")]
        public async Task<CategoryResponse> GetCategoryById([FromRoute] long id)
        {
            return await _categoryService.GetCategoryById(id);
        }

        [HttpPost]
        [Route("createCategory")]
        public async Task CreateCategory(CategoryModel categoryModel)
        {
            await _categoryService.CreateCategory(categoryModel);
        }

        [HttpPost]
        [Route("{categoryId:long}/person/{personId:long}")]
        public async Task AddPerson([FromRoute] long categoryId, [FromRoute] long personId)
        {
            await _categoryService.AddPerson(categoryId, personId);
        }

        [HttpPut]
        [Route("updateCategory")]
        public async Task<CategoryResponse> UpdateCategory(CategoryUpdateModel categoryUpdateModel)
        {
            return await _categoryService.UpdateCategory(categoryUpdateModel);
        }

        [HttpDelete]
        [Route("deleteCategory")]
        public async Task DeleteCategory(long id)
        {
            await _categoryService.DeleteCategory(id);
        }
    }
}
