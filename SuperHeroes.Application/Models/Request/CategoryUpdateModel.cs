using SuperHeroes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroes.Application.Models.Request
{
    public class CategoryUpdateModel
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!; //Marvel or DC
        //public ICollection<CategoryPerson> categoryPeople { get; set; } = null!; //All heroes Marvel or DC
    }
}
