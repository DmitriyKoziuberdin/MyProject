using Microsoft.EntityFrameworkCore;
using SuperHeroes.Application.Interfaces;
using SuperHeroes.Domain;
using SuperHeroes.Domain.Entities;

namespace SuperHeroes.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDBContext _appDbContext;

        public PersonRepository(ApplicationDBContext _appDbContext)
        {
            this._appDbContext = _appDbContext;
        }

        public async Task<List<Person>> GetAllPerson()
        {
            return await _appDbContext.Person.ToListAsync();
        }

        public async Task<Person> GetPersonById(long id)
        {
            return await _appDbContext.Person.FirstOrDefaultAsync(personId=>personId.Id == id);
        }

        public async Task<bool> AnyPersonById(long personId)
        {
            return await _appDbContext.Person.AnyAsync(id => id.Id == personId);
        }

        public async Task CreatePerson(Person person)
        {
            await _appDbContext.Person.AddAsync(person);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<bool> AnyPersonWithSuperHeroName(string personSuperHeroName)
        {
            return await _appDbContext.Person.AnyAsync(n => n.SuperHeroName == personSuperHeroName);
        }

        public async Task UpdatePerson(Person person)
        {
            _appDbContext.Update(person);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<int> DeletePersonById(long id)
        {
            var deletedPerson =await _appDbContext.Person.Where(personId => personId.Id == id).ExecuteDeleteAsync();
            if (deletedPerson > 0)
            {
                await _appDbContext.SaveChangesAsync();
            }
            return deletedPerson;
        }
    }
}
