using SuperHeroes.Application.Models.Request;
using SuperHeroes.Application.Models.Response;
using SuperHeroes.Domain.Entities;

namespace SuperHeroes.Application.Interfaces
{
    public interface IPersonService
    {
        public Task<List<Person>> GetAllPerson();
        public Task<PersonResponse> GetPersonById(long id);
        public Task CreatePerson(PersonModel personModel);
        public Task<PersonResponse> UpdatePerson(PersonUpdateModel personUpdateModel);
        public Task DeletePersonById(long id);
    }
}
