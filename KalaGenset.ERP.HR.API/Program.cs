using FluentValidation;
using KalaGenset.ERP.HR.Core.Interface;

//using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.Facility;
using KalaGenset.ERP.HR.Core.Request.GradeFacilityAssignment;
using KalaGenset.ERP.HR.Core.Request.ProfitcenterMaster;
using KalaGenset.ERP.HR.Core.Services;
using KalaGenset.ERP.HR.Core.Validation.FacilityMaster;
using KalaGenset.ERP.HR.Core.Validation.ProfitcenterMaster;



//using KalaGenset.ERP.HR.Core.Services;
//using KalaGenset.ERP.HR.Core.Validation.FacilityMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.
builder.Configuration.AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true);
builder.Services.AddControllers()
     .AddJsonOptions(options =>
     {
         options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
         options.JsonSerializerOptions.PropertyNamingPolicy = null;
     });

//Configure ConnectionString from appsetting.json file
builder.Services.AddDbContext<KalaDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("KalaDbContext")));

//Dependency Injection services
builder.Services.AddScoped<IFacilityMaster, FacilityMasetrService>();
builder.Services.AddScoped<IValidator<InsertFacilityRequest>, InsertFacilityRequestValidator>();
builder.Services.AddScoped<IValidator<UpdateFacilityRequest>, UpdateFacilityRequestValidator>();

builder.Services.AddScoped<IGradeFacilityAssignment, GradeFacilityAssignmentService>();


builder.Services.AddScoped<IProfitcenterMaster, ProfitcenterMasterService>();
builder.Services.AddScoped<IValidator<InsertProfitcenterRequest>, InsertProfitcenterRequestValidator>();
builder.Services.AddScoped<IValidator<UpdateProfitcenterRequest>, UpdateProfitcenterRequestValidator>();


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
app.MapControllers();
app.Run();
