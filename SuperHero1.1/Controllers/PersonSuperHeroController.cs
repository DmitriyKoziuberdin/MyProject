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
        public async Task<PersonResponseModel> GetPersonById([FromRoute] long id)
        {
            return await _personService.GetPersonById(id);
        }

        [HttpPost]
        [Route("createBudget")]
        public async Task CreatePerson(PersonRequestModel personModel)
        {
           await _personService.CreatePerson(personModel);
        }

        [HttpPut]
        [Route("updatePerson")]
        public async Task<PersonResponseModel> UpdatePerson(PersonUpdateRequestModel personUpdateModel)
        {
            return await _personService.UpdatePerson(personUpdateModel);
        }

        [HttpDelete("{id:long}")]
        public async Task DeletePerson(long id)
        {
            await _personService.DeletePersonById(id);
        }
    }
}