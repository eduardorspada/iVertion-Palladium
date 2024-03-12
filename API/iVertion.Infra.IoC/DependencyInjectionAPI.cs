using iVertion.Application.Interfaces;
using iVertion.Application.Mappings;
using iVertion.Application.Services;
using iVertion.Domain.Account;
using iVertion.Domain.Interfaces;
using iVertion.Infra.Data.Context;
using iVertion.Infra.Data.Identity;
using iVertion.Infra.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace iVertion.Infra.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services,
                                                              IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                {
                    var host = configuration["DBHOST"] ?? "localhost";
                    var port = configuration["DBPORT"] ?? "3306";
                    var user = configuration["DBUSER"] ?? "root";
                    var database = configuration["DBNAME"] ?? "ivertion";
                    var password = configuration["DBPASSWORD"] ?? "";
 
                    string connectionString = $"Server={host};Port={port};Database={database};User ID={user}; Password={password};";
                    options.UseMySql(connectionString,
                                    ServerVersion.AutoDetect(connectionString));
                }
            );

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Repositories
            services.AddScoped<IRepository, Repository>();
            // Articles Repositories
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<IArticleHistoryRepository, ArticleHistoryRepository>();
            
            // Users Profiles and Roles Repositories
            services.AddScoped<IAdditionalUserRoleRepository, AdditionalUserRoleRepository>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            services.AddScoped<IRoleProfileRepository, RoleProfileRepository>();

            // Tickets Panel Repositories
            services.AddScoped<IClientTypeRepository, ClientTypeRepository>();
            services.AddScoped<ICounterRepository, CounterRepository>();
            services.AddScoped<IMerchandisingRepository, MerchandisingRepository>();
            services.AddScoped<IPanelMerchandisingRepository, PanelMerchandisingRepository>();
            services.AddScoped<IPanelRepository, PanelRepository>();
            services.AddScoped<IPreferenceTypeRepository, PreferenceTypeRepository>();
            services.AddScoped<IServiceTypeRepository, ServiceTypeRepository>();
            services.AddScoped<ITicketFollowUpRepository, TicketFollowUpRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<ITicketSubjectRepository, TicketSubjectRepository>();
            services.AddScoped<ITotemPanelRepository, TotemPanelRepository>();
            services.AddScoped<ITotemRepository, TotemRepository>();

            // Services
            // Articles Services
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<IArticleHistoryService, ArticleHistoryService>();

            // Database Initializer Services

            services.AddScoped<IDatabaseInitializer, DatabaseInitializer>();
            
            // User Autorization Services
            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();
            services.AddScoped<IUserInterface<ApplicationUser>, UserService>();
            services.AddScoped<IRoleInterface<IdentityRole>, RoleService>();

            // User Profiles Services
            services.AddScoped<IUserProfileService, UserProfileService>();
            services.AddScoped<IRoleProfileService, RoleProfileService>();
            services.AddScoped<IAdditionalUserRoleService, AdditionalUserRoleService>();

            // AutoMapper for DTOs
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
    }
}