using SuperHeroes.Domain.Entities;

namespace SuperHeroes.Application.Interfaces
{
    public interface IPersonRepository
    {
        public Task<List<Person>> GetAllPerson();
        public Task<Person> GetPersonById(long id);
        public Task<bool> AnyPersonById(long personId);
        public Task<bool> AnyPersonWithSuperHeroName(string personSuperHeroName);
        public Task CreatePerson(Person person);
        public Task UpdatePerson(Person person);
        public Task<int> DeletePersonById(long id);
    }
}
