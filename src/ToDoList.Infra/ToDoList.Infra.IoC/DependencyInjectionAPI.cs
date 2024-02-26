using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Application.Interfaces;
using ToDoList.Application.Profiles;
using ToDoList.Application.Services;
using ToDoList.Domain.Interfaces.RepositoriesInterfaces;
using ToDoList.Infra.Data.Context;
using ToDoList.Infra.Data.Identity;
using ToDoList.Infra.Data.Repositories;

namespace ToDoList.Infra.IoC
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
            services.AddScoped<ICheckListRepository, CheckListRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }

        private static IServiceCollection AddDependencyInjectionServices(this IServiceCollection services)
        {
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<ICheckListService, CheckListService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }

    }
}