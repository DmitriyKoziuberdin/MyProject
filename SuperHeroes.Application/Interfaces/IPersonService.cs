﻿using SuperHeroes.Application.Models.Request;
using SuperHeroes.Application.Models.Response;
using SuperHeroes.Domain.Entities;

namespace SuperHeroes.Application.Interfaces
{
    public interface IPersonService
    {
        public Task<List<Person>> GetAllPerson();
        public Task<PersonResponseModel> GetPersonById(long personId);
        public Task CreatePerson(PersonRequestModel personModel);
        public Task<PersonResponseModel> UpdatePerson(PersonUpdateRequestModel personUpdateModel);
        public Task DeletePersonById(long personId);
    }
}
