using FluentValidation;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Services;
using FluentValidation.AspNetCore;
using KalaGenset.ERP.HR.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using KalaGenset.ERP.HR.Core.Request.Country;
using KalaGenset.ERP.HR.Core.Request.Currency;
using KalaGenset.ERP.HR.Core.Request.District;
using KalaGenset.ERP.HR.Core.Validation.CountryValidation;
using KalaGenset.ERP.HR.Core.Validation.CurrencyValidation;
using KalaGenset.ERP.HR.Core.Validation.CompanyEntityTypeMaster;
using KalaGenset.ERP.HR.Core.Validation.DistrictMasterValidation;
using KalaGenset.ERP.HR.Core.Request.CompanyEntityTypeMaster;
using KalaGenset.ERP.HR.Core.Validation.CityMasterValidation;
using KalaGenset.ERP.HR.Core.Request.City;


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
builder.Services.AddScoped<ICityMaster, CityMasterService>();


//Configure ConnectionString from appsetting.json file
builder.Services.AddDbContext<KalaDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("KalaDbContext")));

// FluentValidation setup
builder.Services.AddFluentValidationClientsideAdapters(); // Enables client-side adapter support
builder.Services.AddValidatorsFromAssemblyContaining<InsertCountryRequestValidator>(); 
builder.Services.AddValidatorsFromAssemblyContaining<UpdateCountryRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<InsertCurrencyRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateCurrencyRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<InsertCompanyEntityTypeRequestValidator>(); // Registers your validator(s)
builder.Services.AddValidatorsFromAssemblyContaining<UpdateCompanyEntityTypeRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<InsertCityRequestValidator>(); 
builder.Services.AddValidatorsFromAssemblyContaining<UpdateCityRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<InsertDistrictRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateDistrictRequestValidator>();
//registering service
builder.Services.AddScoped<ICountryMaster, CountryMasterService>();
builder.Services.AddScoped<IValidator<InsertCountryRequest>, InsertCountryRequestValidator>();
builder.Services.AddScoped<IValidator<UpdateCountryRequest>, UpdateCountryRequestValidator>();
builder.Services.AddScoped<ICurrencyMaster, CurrencyMasterServices>();
builder.Services.AddScoped<IValidator<InsertCurrencyRequest>, InsertCurrencyRequestValidator>();
builder.Services.AddScoped<IValidator<UpdateCurrencyRequest>, UpdateCurrencyRequestValidator>();
builder.Services.AddScoped<IDistrictMaster, DistrictMasterService>();
builder.Services.AddScoped<IValidator<InsertDistrictRequest>, InsertDistrictRequestValidator>();
builder.Services.AddScoped<IValidator<UpdateDistrictRequest>, UpdateDistrictRequestValidator>();
builder.Services.AddScoped<ICompanyEntityTypeMaster, CompanyEntityTypeMasterServices>();
builder.Services.AddScoped<IValidator<InsertCompanyEntityTypeMasterRequest>, InsertCompanyEntityTypeRequestValidator>();
builder.Services.AddScoped<IValidator<UpdateCompanyEntityTypeMasterRequest>, UpdateCompanyEntityTypeRequestValidator>();
builder.Services.AddScoped<ICityMaster, CityMasterService>();
builder.Services.AddScoped<IValidator<InsertCityRequest>, InsertCityRequestValidator>();
builder.Services.AddScoped<IValidator<UpdateCityRequest>, UpdateCityRequestValidator>();

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
// Add services to the container.
builder.Services.AddControllers();

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
app.UseCors("AllowAllOrigins");
app.MapControllers();
app.Run();
