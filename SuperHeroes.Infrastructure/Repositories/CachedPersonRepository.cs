using Microsoft.Extensions.Caching.Memory;
using SuperHeroes.Application.Interfaces;
using SuperHeroes.Domain.Entities;

namespace SuperHeroes.Infrastructure.Repositories
{
    public class CachedPersonRepository : IPersonRepository
    {
        private readonly PersonRepository _personRepository;
        private readonly IMemoryCache _memoryCache;
        private static string _cacheKey = "person";

        public CachedPersonRepository(PersonRepository _personRepository, IMemoryCache _memoryCache)
        {
            this._personRepository = _personRepository;
            this._memoryCache = _memoryCache;
        }

        public async Task<List<Person>> GetAllPerson()
        {
            var persons = await _memoryCache
                .GetOrCreateAsync(_cacheKey, (entry) => _personRepository.GetAllPerson());
            return persons!.ToList();
        }

        public async Task<Person> GetPersonById(long id)
        {
            return await _personRepository.GetPersonById(id);
        }

        public async Task CreatePerson(Person person)
        {
            _memoryCache.Remove(_cacheKey);
            await _personRepository.CreatePerson(person);
        }

        public async Task UpdatePerson(Person person)
        {
            _memoryCache.Remove(_cacheKey);
            await _personRepository.UpdatePerson(person);
        }

        public async Task<int> DeletePersonById(long id)
        {
            _memoryCache.Remove(_cacheKey);
            return await _personRepository.DeletePersonById(id);
        }
    }
}
