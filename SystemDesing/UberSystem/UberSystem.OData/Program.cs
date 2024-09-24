using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using UberSystem.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Phân quyền các role nào được truy cập vào các table ????
var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<Customer>("Customers");
modelBuilder.EntitySet<Cab>("Cabs");
modelBuilder.EntitySet<Driver>("Drivers");
modelBuilder.EntitySet<Trip>("Trips");
modelBuilder.EntitySet<User>("Users");
modelBuilder.EntitySet<Payment>("Payments");

builder.Services.AddControllers().AddOData(
    options => options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null).AddRouteComponents(
        "odata",
        modelBuilder.GetEdmModel()));

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