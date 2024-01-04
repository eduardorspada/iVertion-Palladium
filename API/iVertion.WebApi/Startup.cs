using iVertion.Domain.Account;
using iVertion.Infra.Data.Context;
using iVertion.Infra.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace iVertion.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructureAPI(Configuration);
            services.AddInfrastructureJWT(Configuration);
            services.AddInfrastructureSwagger();
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", builder =>
                {
                    builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
                }
                );
            }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env, ISeedUserRoleInitial seedUserRoleInitial, IDatabaseInitializer databaseInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/iVertion/swagger.json", "iVertion Palladium 1.0"));
                app.UseCors("AllowSpecificOrigin");
            }

            // Configure(
            //     app.ApplicationServices.GetRequiredService<ApplicationDbContext>()
            // );
            
            app.UseHttpsRedirection();
            app.UseStatusCodePages();
            app.UseRouting();

            databaseInitializer.MigrateDatabase();

            seedUserRoleInitial.SeedRoles();
            seedUserRoleInitial.SeedUsers();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}