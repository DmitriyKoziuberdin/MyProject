using Microsoft.AspNetCore.Mvc;
using SuperHeroes.Application.Interfaces;
using SuperHeroes.Application.Models.Request;
using SuperHeroes.Application.Models.Response;
using SuperHeroes.Domain.Entities;

namespace SuperHero1._1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonSuperHeroController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonSuperHeroController(IPersonService _personService)
        {
            this._personService = _personService;
        }

        [HttpGet]
        public async Task<List<Person>> GetAllPerson()
        {
            return await _personService.GetAllPerson();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<PersonResponseModel>> GetPersonById([FromRoute] long id)
        {
            return new OkObjectResult(await _personService.GetPersonById(id));
        }

        [HttpPost("createBudget")]
        public async Task<IActionResult> CreatePerson(PersonRequestModel personModel)
        {
            await _personService.CreatePerson(personModel);
            return Ok();
        }

        [HttpPut("{personId:long}")]
        public async Task<ActionResult<PersonResponseModel>> UpdatePerson([FromRoute] long personId,[FromBody]PersonUpdateRequestModel personUpdateModel)
        {
            return new OkObjectResult(await _personService.UpdatePerson(personUpdateModel));
        }

        [HttpDelete("{personId:long}")]
        public async Task<IActionResult> DeletePerson(long personId)
        {
            await _personService.DeletePersonById(personId);
            return Ok();
        }
    }
}