using Microsoft.EntityFrameworkCore;
using UberSystem.Domain.Models;
using UberSystem.Infrastructure;
using System.Reflection;
using UberSystem.Api.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "NTF API",
        Description = "An ASP.NET Core Web API for managing integrated items",
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
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement {
    {
        new OpenApiSecurityScheme {
            Reference = new OpenApiReference {
                Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
            }
        },
        new string[] {}
    }
    });
    var xfile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xpath = Path.Combine(AppContext.BaseDirectory, xfile);
    options.IncludeXmlComments(xpath);
});
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
var connectionString = builder.Configuration.GetConnectionString("Default");
//DI services
builder.Services.AddDatabase(connectionString).AddServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

// https://learn.microsoft.com/en-us/dotnet/core/tutorials/library-with-visual-studio-code?pivots=dotnet-8-0
