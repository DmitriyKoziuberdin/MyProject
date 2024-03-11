using Common.Exceptions;
using SuperHeroes.Application.Interfaces;
using SuperHeroes.Application.Models.Request;
using SuperHeroes.Application.Models.Response;
using SuperHeroes.ApplicationServices.Models.Response;
using SuperHeroes.Domain.Entities;

namespace SuperHeroes.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<List<Person>> GetAllPerson()
        {
           return await _personRepository.GetAllPerson();
        }

        public async Task<PersonResponseModel> GetPersonById(long personId)
        {
            var isExist = await _personRepository.AnyPersonById(personId);
            if (!isExist)
            {
                throw new PersonNotFoundException($"Person with this ID: {personId} not found.");
            }
            var personById = await _personRepository.GetPersonById(personId);
            var personByIdResponseModel = new PersonResponseModel
            {
                PersonId = personById.Id,
                FirstName = personById.FirstName,
                LastName = personById.LastName,
                SuperHeroName = personById.SuperHeroName,
            };
            return personByIdResponseModel;
        }

        public async Task CreatePerson(PersonRequestModel personRequestModel)
        {
            var isExist = await _personRepository.AnyPersonWithSuperHeroName(personRequestModel.SuperHeroName);
            if (isExist)
            {
                throw new PersonDuplicateCreationSuperHeroName($"Person with this Superhero name - {personRequestModel.SuperHeroName} already exist.");
            }
            await _personRepository.CreatePerson(new Person
            {
                FirstName = personRequestModel.FirstName,
                LastName = personRequestModel.LastName,
                SuperHeroName = personRequestModel.SuperHeroName,
                Age = personRequestModel.Age,
            });
        }

        public async Task<PersonUpdateResponseModel> UpdatePerson(int personId, PersonUpdateRequestModel personUpdateRequestModel)
        {
            var isExist = await _personRepository.AnyPersonById(personId);
            if (!isExist)
            {
                throw new PersonNotFoundException($"Person with this ID: {personId} not found.");
            }

            var personUpdate = new Person
            {
                Id = personId, 
                FirstName = personUpdateRequestModel.FirstName,
                LastName = personUpdateRequestModel.LastName,
                SuperHeroName = personUpdateRequestModel.SuperHeroName,
                Age = personUpdateRequestModel.Age
            };

            
            await _personRepository.UpdatePerson(personUpdate);
            Person personUpdateResponseModel = await _personRepository.GetPersonById(personUpdate.Id);
            return new PersonUpdateResponseModel
            {
                FirstName = personUpdateResponseModel.FirstName,
                LastName = personUpdateResponseModel.LastName,
                SuperHeroName = personUpdateResponseModel.SuperHeroName,
                Age = personUpdateResponseModel.Age
            };
        }

        public async Task DeletePersonById(long personId)
        { 
            var isExist = await _personRepository.AnyPersonById(personId);
            if (!isExist)
            {
                throw new PersonNotFoundException($"Person with this ID: {personId} not found.");
            }
            await _personRepository.DeletePersonById(personId);
        }
    }
}
