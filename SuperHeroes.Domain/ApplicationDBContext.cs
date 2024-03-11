using Microsoft.EntityFrameworkCore;
using SuperHeroes.Domain.Entities;

namespace SuperHeroes.Domain
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Person> Person { get; set; }

        public ApplicationDBContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSnakeCaseNamingConvention();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)  
        {
            //modelBuilder.Entity<Category>()
            //    .HasKey(categoryId => categoryId.Id);

            //modelBuilder.Entity<Category>()
            //    .HasMany(personSuperHeroes => personSuperHeroes.PersonSuperHeroes)
            //    .WithOne(category=>category.Category)
            //    .HasForeignKey(categoryId => categoryId.Id);

            //то же самое внизу, только переписанное в более подходящий вид
            //modelBuilder.Entity<Category>(category =>
            //{
            //    category.HasKey(c => c.Id);
            //    category.HasMany(c => c.PersonSuperHeroes)
            //    .WithOne(category => category.Category)
            //    .HasForeignKey(categoryId => categoryId.categoryId);
            //});

            //modelBuilder.Entity<Person>()
            //    .HasKey(personId => personId.Id);


            //modelBuilder.Entity<Category>()
            //    .HasKey(c => c.Id);

            //modelBuilder.Entity<Category>()
            //    .HasMany(c => c.CategoryPersons)
            //    .WithOne(c => c.Category);

            modelBuilder.Entity<Category>(category =>
            {
                category.HasKey(c => c.Id);
                category.HasMany(c => c.CategoryPersons)
                .WithOne(c => c.Category);
            });

            //modelBuilder.Entity<Person>()
            //    .HasKey(c => c.Id);

            //modelBuilder.Entity<Person>()
            //    .HasMany(c => c.CategoryPersons)
            //    .WithOne(c => c.Person);

            modelBuilder.Entity<Person>(person =>
            {
                person.HasKey(c => c.Id);
                person.HasMany(c => c.CategoryPersons)
                .WithOne(c => c.Person);
            });

            modelBuilder.Entity<CategoryPerson>()
                .HasKey(x => new { x.PersonId, x.CategoryId });
        }   
        
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            UpdateStatistics();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        private void UpdateStatistics()
        {
            var update = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified);
            foreach(var entityEntry in update)
            {
                if(entityEntry.Entity is BaseEntity baseEntity)
                {
                    baseEntity.UpdatedAt = DateTime.UtcNow;
                }
            }

            var create = ChangeTracker.Entries().Where(x => x.State == EntityState.Added);
            foreach (var entityEntry in create)
            {
                if (entityEntry.Entity is BaseEntity baseEntity)
                {
                    baseEntity.CreatedAt = DateTime.UtcNow;
                }
            }
        }
    }
}
