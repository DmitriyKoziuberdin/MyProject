using Microsoft.EntityFrameworkCore;
using SuperHeroes.Application.Interfaces;
using SuperHeroes.Application.Services;
using SuperHeroes.Domain;
using SuperHeroes.Infrastructure.Repositories;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //Configure service
        builder.Services.AddScoped<CategoryRepository>();
        builder.Services.AddScoped<ICategoryRepository, CachedCategoryRepository>();
        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<PersonRepository>();
        builder.Services.AddScoped<IPersonRepository, CachedPersonRepository>();
        builder.Services.AddScoped<IPersonService, PersonService>();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<ApplicationDBContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("ApplicationDataBase"));
        });
        builder.Services.AddMemoryCache();

        var app = builder.Build();

        //Configure
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetService<ApplicationDBContext>()!;
            dbContext.Database.Migrate();
        }
        app.Run();
    }
}