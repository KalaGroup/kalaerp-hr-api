using FluentValidation;
using FluentValidation.AspNetCore;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.Currency;
using KalaGenset.ERP.HR.Core.Services;
using KalaGenset.ERP.HR.Core.Validation.CurrencyValidation;
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

builder.Services.AddDbContext<KalaDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("KalaDbContext")));

builder.Services.AddScoped<ICurrencyMaster, CurrencyMasterServices>();
builder.Services.AddScoped<IValidator<InsertCurrencyRequest>, InsertCurrencyRequestValidator>();
builder.Services.AddScoped<IValidator<UpdateCurrencyRequest>, UpdateCurrencyRequestValidator>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});



builder.Services.AddFluentValidationClientsideAdapters(); // Enables client-side adapter support
builder.Services.AddValidatorsFromAssemblyContaining<InsertCurrencyRequestValidator>(); // Registers your validator(s)

// Add services to the container.

builder.Services.AddControllers();
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

app.UseCors("AllowAllOrigins");
app.MapControllers();

app.Run();
