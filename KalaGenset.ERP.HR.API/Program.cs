using FluentValidation;
using FluentValidation.AspNetCore;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Services;
using KalaGenset.ERP.HR.Core.Validation.CityMasterValidation;
using KalaGenset.ERP.HR.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Configuration.AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true);
builder.Services.AddControllers()
     .AddJsonOptions(options =>
     {
         options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
         options.JsonSerializerOptions.PropertyNamingPolicy = null;
     });

// Add services to the container.
builder.Services.AddDbContext<KalaDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("KalaDbContext")));
builder.Services.AddScoped<ICityMaster, CityMasterService>();
//registering service

builder.Services.AddControllers();

// FluentValidation setup
builder.Services.AddFluentValidationClientsideAdapters(); // Enables client-side adapter support
builder.Services.AddValidatorsFromAssemblyContaining<InsertCityRequestValidatior>(); // Registers your validator(s)


// Enable CORS globally
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("AllowAllOrigins"); // Use the CORS policy

app.MapControllers();

app.Run();
