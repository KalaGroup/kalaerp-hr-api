using FluentValidation;
using FluentValidation.AspNetCore;
using KalaERP.HR.Core.Interface;
using KalaERP.HR.Core.Request.CompanyMaster;
using KalaERP.HR.Core.Request.DesignationMaster;
using KalaERP.HR.Core.Services;
using KalaERP.HR.Core.Validation.Company;
using KalaERP.HR.Core.Validation.DesignationMaster;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request;
using KalaGenset.ERP.HR.Core.Request.AuthoritieMaster;
using KalaGenset.ERP.HR.Core.Request.City;
using KalaGenset.ERP.HR.Core.Request.ClassOfTravel;
using KalaGenset.ERP.HR.Core.Request.CompanyEntityTypeMaster;
using KalaGenset.ERP.HR.Core.Request.Country;
using KalaGenset.ERP.HR.Core.Request.Currency;
using KalaGenset.ERP.HR.Core.Request.Department;
using KalaGenset.ERP.HR.Core.Request.District;
using KalaGenset.ERP.HR.Core.Request.Facility;
using KalaGenset.ERP.HR.Core.Request.Grade;
using KalaGenset.ERP.HR.Core.Request.KPAMaster;
using KalaGenset.ERP.HR.Core.Request.LocationRequest;
using KalaGenset.ERP.HR.Core.Request.ProfitcenterMaster;
using KalaGenset.ERP.HR.Core.Request.QualificationRequest;
using KalaGenset.ERP.HR.Core.Request.ResposibilitiesMaster;
using KalaGenset.ERP.HR.Core.Request.StateRequest;
using KalaGenset.ERP.HR.Core.Request.Workstation;
using KalaGenset.ERP.HR.Core.Services;
using KalaGenset.ERP.HR.Core.Validation.AuthoritieMaster;
using KalaGenset.ERP.HR.Core.Validation.CityMasterValidation;
using KalaGenset.ERP.HR.Core.Validation.ClassOfTravelValidation;
using KalaGenset.ERP.HR.Core.Validation.CompanyEntityTypeMaster;
using KalaGenset.ERP.HR.Core.Validation.CountryValidation;
using KalaGenset.ERP.HR.Core.Validation.CurrencyValidation;
using KalaGenset.ERP.HR.Core.Validation.DepartmentMaster;
using KalaGenset.ERP.HR.Core.Validation.DepartmentValidation;
using KalaGenset.ERP.HR.Core.Validation.DistrictMasterValidation;
using KalaGenset.ERP.HR.Core.Validation.FacilityMaster;
using KalaGenset.ERP.HR.Core.Validation.GradeValidation;
using KalaGenset.ERP.HR.Core.Validation.KPAMaster;
using KalaGenset.ERP.HR.Core.Validation.LocationValidator;
using KalaGenset.ERP.HR.Core.Validation.PetrolAllowanceMaster;
using KalaGenset.ERP.HR.Core.Validation.ProfitcenterMaster;
using KalaGenset.ERP.HR.Core.Validation.QualificationTypeMaster;
using KalaGenset.ERP.HR.Core.Validation.QualificationValidator;
using KalaGenset.ERP.HR.Core.Validation.StateValidator;
using KalaGenset.ERP.HR.Core.Validation.WorkstationMasterValidation;
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

//Configure ConnectionString from appsetting.json file
builder.Services.AddDbContext<KalaDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("KalaDbContext")));
// FluentValidation setup
builder.Services.AddFluentValidationClientsideAdapters(); // Enables client-side adapter support
builder.Services.AddValidatorsFromAssemblyContaining<InsertCountryRequestValidator>(); 
builder.Services.AddValidatorsFromAssemblyContaining<UpdateCountryRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<InsertCurrencyRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateCurrencyRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<InsertCompanyEntityTypeRequestValidator>(); 
builder.Services.AddValidatorsFromAssemblyContaining<UpdateCompanyEntityTypeRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<InsertCityRequestValidator>(); 
builder.Services.AddValidatorsFromAssemblyContaining<UpdateCityRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<InsertDistrictRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateDistrictRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<InsertStateRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<InsertQualificationRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<InsertLocationRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<InsertAuthoritieMasterValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateAuthoritieMasterValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<InsertWorkstationRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<InsertKPAMasterValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateKPAMasterValidator>();

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
builder.Services.AddScoped<IFacilityMaster, FacilityMasterService>(); 
builder.Services.AddScoped<IValidator<InsertFacilityRequest>, InsertFacilityRequestValidator>();
builder.Services.AddScoped<IValidator<UpdateFacilityRequest>, UpdateFacilityRequestValidator>();
builder.Services.AddScoped<IProfitcenterMaster, ProfitcenterMasterService>();
builder.Services.AddScoped<IValidator<InsertProfitcenterRequest>, InsertProfitcenterRequestValidator>();
builder.Services.AddScoped<IValidator<UpdateProfitcenterRequest>, UpdateProfitcenterRequestValidator>();
builder.Services.AddScoped<IGradeFacilityAssignment, GradeFacilityAssignmentService>();
builder.Services.AddScoped<IStateMaster, StateMasterService>();
builder.Services.AddScoped<IQualificationMaster, QualificationMasterService>();
builder.Services.AddScoped<ILocationMaster, LocationMasterService>();
builder.Services.AddScoped<IValidator<InsertStateRequest>, InsertStateRequestValidator>();
builder.Services.AddScoped<IValidator<InsertQualificationRequest>, InsertQualificationRequestValidator>();
builder.Services.AddScoped<IValidator<InsertLocationRequest>, InsertLocationRequestValidator>();
builder.Services.AddScoped<IValidator<UpdateStateRequest>, UpdateStateValidator>();
builder.Services.AddScoped<IValidator<UpdateQualificationRequest>, UpdateQualificationValidator>();
builder.Services.AddScoped<IValidator<UpdateLocationRequest>, UpdateLocationValidator>();
builder.Services.AddScoped<IQualificationTypeMaster, QualificationTypeMasterService>();
builder.Services.AddScoped<IValidator<InsertQualificationTypeMasterRequest>,InsertQualTypeMstRequestValidator>();
builder.Services.AddScoped<IValidator<UpdateQualificationTypeMasterRequest>, UpdateQualTypeMstRequestValidator>();
builder.Services.AddScoped<IPetrolAllowanceMaster, PetrolAllowanceMasterService>();
builder.Services.AddScoped<IValidator<InsertPetrolAllowanceMasterRequest>, InsertPetrolAllowanceRequestValidator>();
builder.Services.AddScoped<IValidator<UpdatePetrolAllowanceMasterRequest>,UpdatePetrolAllowanceRequestValidator>();
builder.Services.AddScoped<IDepartmentMaster, DepartmentMasterService>();
builder.Services.AddScoped<IValidator<InsertDepartmentRequest>, InsertDepartmentRequestValidator>();
builder.Services.AddScoped<IValidator<UpdateDepartmentRequest>, UpdateDepartmentRequestValidator>();
builder.Services.AddScoped<IGradeMaster, GradeMasterService>();
builder.Services.AddScoped<IValidator<InsertGradeRequest>, InsertGradeRequestValidator>();
builder.Services.AddScoped<IValidator<UpdateGradeRequest>, UpdateGradeRequestValidator>();
builder.Services.AddScoped<IClassOfTravelMaster, ClassOfTravelMasterService>();
builder.Services.AddScoped<IValidator<InsertClassOfTravelRequest>, InsertClassOfTravelRequestValidator>();
builder.Services.AddScoped<IValidator<UpdateClassOfTravelRequest>, UpdateClassOfTravelRequestValidator>();
builder.Services.AddScoped<ICompanyMaster, CompanyMasterServices>();
builder.Services.AddScoped<IValidator<InsertCompanyRequest>, InsertCompanyRequestValidator>();
builder.Services.AddScoped<IValidator<UpdateCompanyRequest>, UpdateCompanyValidator>();
builder.Services.AddScoped<IDesignationMaster, DesignationMasterServices>();
builder.Services.AddScoped<IValidator<InsertDesignationMasterRequest>, InsertDesignationValidator>();
builder.Services.AddScoped<IValidator<UpdateDesignationMasterRequest>, UpdateDesignationValidator>();
builder.Services.AddScoped<IResposibilitiesMaster, ResposibilitiesMasterServices>();
builder.Services.AddScoped<IValidator<InsertResposibilitiesMasterRequest>, InsertResposibilitiesMasterValidator>();
builder.Services.AddScoped<IValidator<UpdateResposibilitiesMasterRequest>, UpdateResposibilitiesMasterValidator>();
builder.Services.AddScoped<IResposibilitiesDetail, ResposibilitiesDetailsServices>();
builder.Services.AddScoped<IAuthoritieMaster, AuthoritieMasterServices>();
builder.Services.AddScoped<IValidator<InsertAuthoritieMasterRequest>, InsertAuthoritieMasterValidator>();
builder.Services.AddScoped<IValidator<UpdateAuthoritieMasterRequest>, UpdateAuthoritieMasterValidator>();
builder.Services.AddScoped<IAuthoritiesDetail, AuthoritiesDetailServices>(); 
builder.Services.AddScoped<IWorkstationMaster, WorkstationMasterService>();
builder.Services.AddScoped<IValidator<InsertWorkstationRequest>, InsertWorkstationRequestValidator>();
builder.Services.AddScoped<IValidator<UpdateWorkstationRequest>, UpdateWorkstationMasterValidator>();
builder.Services.AddScoped<IKPAMaster, KPAMasterServices>();
builder.Services.AddScoped<IValidator<InsertKPAMasterRequest>, InsertKPAMasterValidator>();
builder.Services.AddScoped<IValidator<UpdateKPAMasterRequest>, UpdateKPAMasterValidator>();
builder.Services.AddScoped<IKpadetail, KPADetailsServices>();


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
