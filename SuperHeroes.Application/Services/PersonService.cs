using SuperHeroes.Application.Interfaces;
using SuperHeroes.Application.Models.Request;
using SuperHeroes.Application.Models.Response;
using SuperHeroes.Domain.Entities;

namespace SuperHeroes.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository _personRepository)
        {
            this._personRepository = _personRepository;
        }

        public async Task<List<Person>> GetAllPerson()
        {
           return await _personRepository.GetAllPerson();
        }

        public async Task<PersonResponse> GetPersonById(long id)
        {
            var personById = await _personRepository.GetPersonById(id);
            var personByIdResponse = new PersonResponse
            {
                PersonId= personById.Id,
                FirstName= personById.FirstName,
                LastName= personById.LastName,
                SuperHeroName= personById.SuperHeroName,
            };
            return personByIdResponse;
        }

        public async Task CreatePerson(PersonModel personModel)
        {
            //after add exception for this method
            await _personRepository.CreatePerson(new Person
            {
                FirstName = personModel.FirstName,
                LastName = personModel.LastName,
                SuperHeroName = personModel.SuperHeroName,
                Age = personModel.Age,
            });
        }

        public async Task<PersonResponse> UpdatePerson(PersonUpdateModel personUpdateModel)
        {
            var personUpdate = new Person
            {
                Id = personUpdateModel.PersonId, 
                FirstName = personUpdateModel.FirstName,
                LastName = personUpdateModel.LastName,
                SuperHeroName = personUpdateModel.SuperHeroName,
                Age = personUpdateModel.Age
            };

            await _personRepository.UpdatePerson(personUpdate);
            Person personUpdateResponse = await _personRepository.GetPersonById(personUpdate.Id);
            return new PersonResponse
            {
                PersonId = personUpdateModel.PersonId,
                FirstName = personUpdateModel.FirstName,
                LastName = personUpdateModel.LastName,
                SuperHeroName = personUpdateModel.SuperHeroName,
                Age = personUpdateModel.Age
            };
        }

        public async Task DeletePersonById(long id)
        {
            var deletedPerson = _personRepository.DeletePersonById(id);
            if (deletedPerson == null)
            {
                throw new Exception("Person with this ID does't exist");
            }
            await deletedPerson;
        }
    }
}
