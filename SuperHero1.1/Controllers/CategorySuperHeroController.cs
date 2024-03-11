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
        public async Task<ActionResult<CategoryResponseModel>> GetCategoryById([FromRoute] long id)
        {
            return new OkObjectResult(await _categoryService.GetCategoryById(id));
        }

        [HttpPost("createCategory")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryRequestModel categoryModel)
        {
            await _categoryService.CreateCategory(categoryModel);
            return Ok();
        }

        [HttpPost("{categoryId:long}/person/{personId:long}")]
        public async Task<IActionResult> AddPerson([FromRoute] long categoryId, [FromRoute] long personId)
        {
            await _categoryService.AddPerson(categoryId, personId);
            return Ok();
        }

        [HttpPut("{categoryId:int}/")]
        public async Task<ActionResult<CategoryResponseModel>> UpdateCategory([FromRoute] int categoryId, [FromBody] CategoryUpdateRequestModel categoryUpdateModel)
        {
            return new OkObjectResult(await _categoryService.UpdateCategory(categoryId, categoryUpdateModel));
        }

        [HttpDelete("{categoryId:long}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] long categoryId)
        {
            await _categoryService.DeleteCategory(categoryId);
            return Ok();
        }
    }
}
