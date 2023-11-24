using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Application.Profiles;
using ToDoList.Domain.Interfaces.RepositoriesInterfaces;
using ToDoList.Infra.Data.Context;
using ToDoList.Infra.Data.Identity;
using ToDoList.Infra.Data.Repositories;

namespace ToDoList.Infra.Ioc
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddAutoMapper(typeof(MainProfile));

            services.ConfigureDatabase(configuration);
            services.AddDependencyInjectionRepositories();
            services.AddDependencyInjectionServices();

            return services;
        }

        private static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            if (connectionString == null)
            {
                //TODO: Search a better exception to throw in this situation.
                throw new Exception("Connection string is not setted.");
            }

            services.AddDbContext<ApplicationDbContext>(opt =>
                                                            opt.UseSqlServer(connectionString,
                                                                             b => b.MigrationsAssembly(typeof(ApplicationDbContext)
                                                                                                            .Assembly
                                                                                                            .FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }

        private static IServiceCollection AddDependencyInjectionRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<CheckListRepository, CheckListRepository>();
            services.AddScoped<ItemRepository, ItemRepository>();

            return services;
        }

        private static IServiceCollection AddDependencyInjectionServices(this IServiceCollection services)
        {
            //TODO: Register dependency injection services here.
            return services;
        }

    }
}