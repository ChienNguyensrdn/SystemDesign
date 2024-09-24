using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using UberSystem.Domain.Interfaces;
using UberSystem.Domain.Interfaces.Services;
using UberSystem.Infrastructure;
using UberSystem.Service;
using UberSytem.Dto;

namespace UberSystem.Api.Customer.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection Register(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "UberSystem.Api.Customer",
                    Description = "An ASP.NET Core Web API for managing customers",
                    TermsOfService = new Uri("https://lms-hcmuni.fpt.edu.vn/course/view.php?id=2110"),
                    Contact = new OpenApiContact
                    {
                        Name = "Contact",
                        Url = new Uri("https://lms-hcmuni.fpt.edu.vn/course/view.php?id=2110")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "License",
                        Url = new Uri("https://lms-hcmuni.fpt.edu.vn/course/view.php?id=2110")
                    }
                });
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });

                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                // Set the comments path for the Swagger JSON and UI.
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                opt.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

            });
            // Register database
            var connectionString = configuration.GetConnectionString("Default") ?? string.Empty;
            services.AddDatabase(connectionString);
            // Application services
            services.AddApplicationServices();

            // AutoMapper
            services.AddAutoMapper(typeof(MappingProfileExtension));
            return services;
        }

        private static IServiceCollection AddDatabase(this IServiceCollection services, string connection)
        {
            services.AddDbContext<UberSystemDbContext>(opt =>
            {
                opt.UseSqlServer(connection, sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.CommandTimeout(120);
                });
            });
            services.AddScoped<DbFactory>();
            services.AddScoped<Func<UberSystemDbContext>>(provider => () => provider.GetService<UberSystemDbContext>());
            return services;
        }

        private static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
