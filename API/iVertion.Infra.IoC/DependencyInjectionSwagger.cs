using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace iVertion.Infra.IoC
{
    public static class DependencyInjectionSwagger
    {
        public static IServiceCollection AddInfrastructureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                var apiXmlCommentsFile = Path.Combine(AppContext.BaseDirectory, "iVertion.WebApi.xml");
                c.SwaggerDoc("iVertion", new OpenApiInfo {
                                                    Title = "iVertion WebApi", 
                                                    Version = "1.0",
                                                    TermsOfService = new Uri("http://ivertion.com/TermsOfService"),
                                                    Description = "iVertion Web Api is a service that manages the entire iVertion application suite.",
                                                    License = new OpenApiLicense
                                                    {
                                                        Name = "iVertion License",
                                                        Url = new Uri("http://mit.com")
                                                    },
                                                    Contact = new OpenApiContact
                                                    {
                                                        Name = "Eduardo Rodrigo Spada",
                                                        Email = "eduardo.spada@mundodosoftware.com",
                                                        Url = new Uri("https://mundodosoftware.com")
                                                        
                                                    }

                                                    }
                            );
                if (File.Exists(apiXmlCommentsFile))
                {
                    c.IncludeXmlComments(apiXmlCommentsFile);
                }
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name="Authorization",
                    Type= SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat ="JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] " +
                    "and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });
            });
            return services;
        }
    }
}