using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.EmployeeMaster;
using KalaGenset.ERP.HR.Core.ResponseDTO.EmployeeMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Services
{
    public class EmployeeMasterServices : IEmployeeMaster
    {
        private readonly KalaDbContext dbContext;
        public EmployeeMasterServices(KalaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddEmployeeMasterAsync(InsertEmployeeMasterRequest request)
        {
            using var transaction = await dbContext.Database.BeginTransactionAsync();
            try
            {
                // 1️⃣ Insert Employee Master
                var employee = new EmployeeMasterPersonalDetail
                {
                    EmployeeMasterCode = request.EmployeeMasterCode,
                    EmployeeMasterFirstName = request.EmployeeMasterFirstName,
                    EmployeeMasterMiddleName = request.EmployeeMasterMiddleName,
                    EmployeeMasterLastName = request.EmployeeMasterLastName,
                    EmployeeMasterFullName = request.EmployeeMasterFullName,
                    EmployeeMasterDateOfBirth = request.EmployeeMasterDateOfBirth,
                    EmployeeMasterGender = request.EmployeeMasterGender,
                    EmployeeMasterNationalityCountryId = request.EmployeeMasterNationalityCountryId,
                    EmployeeMasterReligion = request.EmployeeMasterReligion,
                    EmployeeMasterReligionCategory = request.EmployeeMasterReligionCategory,
                    EmployeeMasterBloodGroup = request.EmployeeMasterBloodGroup,
                    EmployeeMasterPhotoAttachment = request.EmployeeMasterPhotoAttachment,
                    EmployeeMasterRemark = request.EmployeeMasterRemark,
                    EmployeeMasterAuthRemark = request.EmployeeMasterAuthRemark,
                    EmployeeMasterAuth = request.EmployeeMasterAuth,
                    EmployeeMasterIsDiscard = request.EmployeeMasterIsDiscard,
                    EmployeeMasterIsActive = request.EmployeeMasterIsActive,
                    CreatedBy = request.CreatedBy,
                    CreatedDate = request.CreatedDate,
                    UpdatedBy = request.UpdatedBy,
                    UpdatedDate = request.UpdatedDate
                };

                dbContext.EmployeeMasterPersonalDetails.Add(employee);

                // 🔑 Save first to generate EmployeeMasterId
                await dbContext.SaveChangesAsync();

                // 2️⃣ Retrieve auto-generated ID
                int employeeMasterId = employee.EmployeeMasterId;

                // 3️⃣ Insert Family Details if available
                if (request.FamilyDetails != null && request.FamilyDetails.Any())
                {
                    var families = request.FamilyDetails.Select(f => new EmployeeMasterFamilyDetail
                    {
                        FamilyDetailsEmployeeMasterId = employeeMasterId,
                        FamilyDetailsEmployeeMasterFatherHusbandName = f.FamilyDetailsEmployeeMasterFatherHusbandName,
                        FamilyDetailsEmployeeMasterMotherName = f.FamilyDetailsEmployeeMasterMotherName,
                        FamilyDetailsEmployeeMasterMartialStatus = f.FamilyDetailsEmployeeMasterMartialStatus,
                        FamilyDetailsEmployeeMasterSpouseName = f.FamilyDetailsEmployeeMasterSpouseName,
                        FamilyDetailsEmployeeMasterSpouseDateOfBirth = f.FamilyDetailsEmployeeMasterSpouseDateOfBirth,
                        FamilyDetailsEmployeeMasterSpouseAadharNumber = f.FamilyDetailsEmployeeMasterSpouseAadharNumber,
                        FamilyDetailsEmployeeMasterNumberofChidren = f.FamilyDetailsEmployeeMasterNumberofChidren,
                        FamilyDetailsEmployeeMasterSpouseAadharNumberAttachment = f.FamilyDetailsEmployeeMasterSpouseAadharNumberAttachment,
                        FamilyDetailsEmployeeMasterRemark = f.FamilyDetailsEmployeeMasterRemark,
                        FamilyDetailsEmployeeMasterAuthRemark = f.FamilyDetailsEmployeeMasterAuthRemark,
                        FamilyDetailsEmployeeMasterAuth = f.FamilyDetailsEmployeeMasterAuth,
                        UpdatedDate = f.UpdatedDate,
                        UpdatedBy = f.UpdatedBy
                    }).ToList();

                    dbContext.EmployeeMasterFamilyDetails.AddRange(families);
                }

                // 4️⃣ Insert Address Details if available
                if (request.AddressDetails != null && request.AddressDetails.Any())
                {
                    var addresses = request.AddressDetails.Select(a => new EmployeeMasterAddressDetail
                    {
                        AddressDetailsEmployeeMasterId = employeeMasterId,
                        AddressDetailsEmployeeMasterPresentAdress = a.AddressDetailsEmployeeMasterPresentAdress,
                        AddressDetailsEmployeeMasterPresentCountryId = a.AddressDetailsEmployeeMasterPresentCountryId,
                        AddressDetailsEmployeeMasterPresentStateId = a.AddressDetailsEmployeeMasterPresentStateId,
                        AddressDetailsEmployeeMasterPresentDistrictId = a.AddressDetailsEmployeeMasterPresentDistrictId,
                        AddressDetailsEmployeeMasterPresentCitytId = a.AddressDetailsEmployeeMasterPresentCitytId,
                        AddressDetailsEmployeeMasterPresentPinCode = a.AddressDetailsEmployeeMasterPresentPinCode,
                        AddressDetailsEmployeeMasterPemanantAddresssameAsPresent = a.AddressDetailsEmployeeMasterPemanantAddresssameAsPresent,
                        AddressDetailsEmployeeMasterPermanantAdress = a.AddressDetailsEmployeeMasterPermanantAdress,
                        AddressDetailsEmployeeMasterPermanantCountryId = a.AddressDetailsEmployeeMasterPermanantCountryId,
                        AddressDetailsEmployeeMasterPermanantStateId = a.AddressDetailsEmployeeMasterPermanantStateId,
                        AddressDetailsEmployeeMasterPermanantDistrictId = a.AddressDetailsEmployeeMasterPermanantDistrictId,
                        AddressDetailsEmployeeMasterPermanantCityId = a.AddressDetailsEmployeeMasterPermanantCityId,
                        AddressDetailsEmployeeMasterPermanantPinCode = a.AddressDetailsEmployeeMasterPermanantPinCode,
                        AddressDetailsEmployeeMasterAuthRemark = a.AddressDetailsEmployeeMasterAuthRemark,
                        AddressDetailsEmployeeMasterAuth = a.AddressDetailsEmployeeMasterAuth,
                        UpdatedDate = a.UpdatedDate,
                        UpdatedBy = a.UpdatedBy
                    }).ToList();

                    dbContext.EmployeeMasterAddressDetails.AddRange(addresses);
                }

                // 5️⃣ Insert Employment Details if available
                if (request.EmploymentDetails != null && request.EmploymentDetails.Any())
                {
                    var employments = request.EmploymentDetails.Select(e => new EmployeeMasterEmploymentDetail
                    {
                        EmploymentDetailsEmployeeMasterId = employeeMasterId,
                        EmploymentDetailsDivisionId = e.EmploymentDetailsDivisionId,
                        EmploymentDetailsPositionId = e.EmploymentDetailsPositionId,
                        EmploymentDetailsOfferLetterId = e.EmploymentDetailsOfferLetterId,
                        EmploymentDetailsEmployeeTypeId = e.EmploymentDetailsEmployeeTypeId,
                        EmploymentDetailsParentCompanyId = e.EmploymentDetailsParentCompanyId,
                        EmploymentDetailsCompanyEntityId = e.EmploymentDetailsCompanyEntityId,
                        EmploymentDetailsProfitcenterId = e.EmploymentDetailsProfitcenterId,
                        EmploymentDetailsDepartmentId = e.EmploymentDetailsDepartmentId,
                        EmploymentDetailsWorkastationId = e.EmploymentDetailsWorkastationId,
                        EmploymentDetailsGradeId = e.EmploymentDetailsGradeId,
                        EmploymentDetailsDesignationId = e.EmploymentDetailsDesignationId,
                        EmploymentDetailsReportToId = e.EmploymentDetailsReportToId,
                        EmploymentDetailsReportDepartmentHodid = e.EmploymentDetailsReportDepartmentHodid,
                        EmploymentDetailsRemark = e.EmploymentDetailsRemark,
                        EmploymentDetailsAuth1Remark = e.EmploymentDetailsAuth1Remark,
                        EmploymentDetailsAuth2Remark = e.EmploymentDetailsAuth2Remark,
                        EmploymentDetailsAuth3Remark = e.EmploymentDetailsAuth3Remark,
                        EmploymentDetailsAuth1 = e.EmploymentDetailsAuth1,
                        EmploymentDetailsAuth2 = e.EmploymentDetailsAuth2,
                        EmploymentDetailsAuth3 = e.EmploymentDetailsAuth3,
                        UpdatedDate = e.UpdatedDate,
                        UpdatedBy = e.UpdatedBy
                    }).ToList();

                    dbContext.EmployeeMasterEmploymentDetails.AddRange(employments);
                }

                // ✅ Commit all at once
                await dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw; // log exception
            }
        }

        public async Task DeleteEmployeeMasterAsync(int employeeMasterId)
        {
            if (employeeMasterId <= 0)
                throw new ArgumentException("EmployeeMasterId must be valid.", nameof(employeeMasterId));

            using var transaction = await dbContext.Database.BeginTransactionAsync();
            try
            {
                // 1️⃣ Retrieve Employee Master
                var employee = await dbContext.EmployeeMasterPersonalDetails
                    .FirstOrDefaultAsync(e => e.EmployeeMasterId == employeeMasterId);

                if (employee == null)
                    throw new KeyNotFoundException($"Employee with ID {employeeMasterId} not found.");

                // 2️⃣ Soft-delete the employee
                employee.EmployeeMasterIsActive = false;
                dbContext.EmployeeMasterPersonalDetails.Update(employee);

                // 3️⃣ Optional: Soft-delete related Family Details
                var familyDetails = await dbContext.EmployeeMasterFamilyDetails
                    .Where(f => f.FamilyDetailsEmployeeMasterId == employeeMasterId)
                    .ToListAsync();

                if (familyDetails.Any())
                {
                    foreach (var f in familyDetails)
                    dbContext.EmployeeMasterFamilyDetails.UpdateRange(familyDetails);
                }

                // 4️⃣ Optional: Soft-delete related Address Details
                var addressDetails = await dbContext.EmployeeMasterAddressDetails
                    .Where(a => a.AddressDetailsEmployeeMasterId == employeeMasterId)
                    .ToListAsync();

                if (addressDetails.Any())
                {
                    foreach (var a in addressDetails)
                    dbContext.EmployeeMasterAddressDetails.UpdateRange(addressDetails);
                }

                // 5️⃣ Optional: Soft-delete related Employment Details
                var employmentDetails = await dbContext.EmployeeMasterEmploymentDetails
                    .Where(e => e.EmploymentDetailsEmployeeMasterId == employeeMasterId)
                    .ToListAsync();

                if (employmentDetails.Any())
                {
                    foreach (var e in employmentDetails)
                    dbContext.EmployeeMasterEmploymentDetails.UpdateRange(employmentDetails);
                }

                // 6️⃣ Save changes
                await dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }


        public async Task<IEnumerable<EmployeeMasterDTO>> GetAllEmployeeMasterAsync()
        {
            var result = await dbContext.EmployeeMasterPersonalDetails
                .Where(emp => emp.EmployeeMasterIsActive) // Only active employees
                .Select(emp => new EmployeeMasterDTO
                {
                    EmployeeMasterId = emp.EmployeeMasterId,
                    EmployeeMasterCode = emp.EmployeeMasterCode,
                    EmployeeMasterFirstName = emp.EmployeeMasterFirstName,
                    EmployeeMasterMiddleName = emp.EmployeeMasterMiddleName,
                    EmployeeMasterLastName = emp.EmployeeMasterLastName,
                    EmployeeMasterFullName = emp.EmployeeMasterFullName,
                    EmployeeMasterDateOfBirth = emp.EmployeeMasterDateOfBirth,
                    EmployeeMasterGender = emp.EmployeeMasterGender,
                    //EmployeeMasterNationalityCountryId = emp.EmployeeMasterNationalityCountryId,
                    CountryName=emp.EmployeeMasterNationalityCountry.CountryName,
                    EmployeeMasterReligion = emp.EmployeeMasterReligion,
                    EmployeeMasterReligionCategory = emp.EmployeeMasterReligionCategory,
                    EmployeeMasterBloodGroup = emp.EmployeeMasterBloodGroup,
                    EmployeeMasterPhotoAttachment = emp.EmployeeMasterPhotoAttachment,
                    EmployeeMasterRemark = emp.EmployeeMasterRemark,
                    EmployeeMasterAuthRemark = emp.EmployeeMasterAuthRemark,
                    EmployeeMasterAuth = emp.EmployeeMasterAuth,
                    EmployeeMasterIsDiscard = emp.EmployeeMasterIsDiscard,
                    EmployeeMasterIsActive = emp.EmployeeMasterIsActive,
                    CreatedBy = emp.CreatedBy,
                    CreatedDate = emp.CreatedDate,
                    UpdatedBy = emp.UpdatedBy,
                    UpdatedDate = emp.UpdatedDate,

                    // Family Details
                    FamilyDetails = emp.EmployeeMasterFamilyDetails.Select(f => new EmployeeMasterFamilyDTO
                    {
                        EmployeeMasterFamilyDetailsId = f.EmployeeMasterFamilyDetailsId,
                        //FamilyDetailsEmployeeMasterId = f.FamilyDetailsEmployeeMasterId,
                      EmployeeMasterFullName=f.FamilyDetailsEmployeeMaster.EmployeeMasterFullName,
                        FamilyDetailsEmployeeMasterFatherHusbandName = f.FamilyDetailsEmployeeMasterFatherHusbandName,
                        FamilyDetailsEmployeeMasterMotherName = f.FamilyDetailsEmployeeMasterMotherName,
                        FamilyDetailsEmployeeMasterMartialStatus = f.FamilyDetailsEmployeeMasterMartialStatus,
                        FamilyDetailsEmployeeMasterSpouseName = f.FamilyDetailsEmployeeMasterSpouseName,
                        FamilyDetailsEmployeeMasterSpouseDateOfBirth = f.FamilyDetailsEmployeeMasterSpouseDateOfBirth,
                        FamilyDetailsEmployeeMasterSpouseAadharNumber = f.FamilyDetailsEmployeeMasterSpouseAadharNumber,
                        FamilyDetailsEmployeeMasterNumberofChidren = f.FamilyDetailsEmployeeMasterNumberofChidren,
                        FamilyDetailsEmployeeMasterSpouseAadharNumberAttachment = f.FamilyDetailsEmployeeMasterSpouseAadharNumberAttachment,
                        FamilyDetailsEmployeeMasterRemark = f.FamilyDetailsEmployeeMasterRemark,
                        FamilyDetailsEmployeeMasterAuthRemark = f.FamilyDetailsEmployeeMasterAuthRemark,
                        FamilyDetailsEmployeeMasterAuth = f.FamilyDetailsEmployeeMasterAuth,
                        UpdatedDate = f.UpdatedDate,
                        UpdatedBy = f.UpdatedBy
                    }).ToList(),

                    // Address Details
                    AddressDetails = emp.EmployeeMasterAddressDetails.Select(a => new EmployeeMasterAddressDTO
                    {
                        EmployeeMasterAddressDetailsId = a.EmployeeMasterAddressDetailsId,
                        //AddressDetailsEmployeeMasterId = a.AddressDetailsEmployeeMasterId,
                        EmployeeMasterFullName=a.AddressDetailsEmployeeMaster.EmployeeMasterFullName,
                        AddressDetailsEmployeeMasterPresentAdress = a.AddressDetailsEmployeeMasterPresentAdress,
                        //AddressDetailsEmployeeMasterPresentCountryId = a.AddressDetailsEmployeeMasterPresentCountryId,
                        //AddressDetailsEmployeeMasterPresentStateId = a.AddressDetailsEmployeeMasterPresentStateId,
                        //AddressDetailsEmployeeMasterPresentDistrictId = a.AddressDetailsEmployeeMasterPresentDistrictId,
                        //AddressDetailsEmployeeMasterPresentCitytId = a.AddressDetailsEmployeeMasterPresentCitytId,
                        AddressDetailsEmployeeMasterPresentPinCode = a.AddressDetailsEmployeeMasterPresentPinCode,
                        CountryName=a.AddressDetailsEmployeeMasterPermanantCountry.CountryName,
                        StateName=a.AddressDetailsEmployeeMasterPermanantState.StateName,
                        DistrictName=a.AddressDetailsEmployeeMasterPresentDistrict.DistrictName,
                        CityName=a.AddressDetailsEmployeeMasterPermanantCity.CityName,
                        AddressDetailsEmployeeMasterPemanantAddresssameAsPresent = a.AddressDetailsEmployeeMasterPemanantAddresssameAsPresent,
                        AddressDetailsEmployeeMasterPermanantAdress = a.AddressDetailsEmployeeMasterPermanantAdress,
                        AddressDetailsEmployeeMasterPermanantCountryId = a.AddressDetailsEmployeeMasterPermanantCountryId,
                        AddressDetailsEmployeeMasterPermanantStateId = a.AddressDetailsEmployeeMasterPermanantStateId,
                        AddressDetailsEmployeeMasterPermanantDistrictId = a.AddressDetailsEmployeeMasterPermanantDistrictId,
                        AddressDetailsEmployeeMasterPermanantCityId = a.AddressDetailsEmployeeMasterPermanantCityId,
                        AddressDetailsEmployeeMasterPermanantPinCode = a.AddressDetailsEmployeeMasterPermanantPinCode,
                        AddressDetailsEmployeeMasterAuthRemark = a.AddressDetailsEmployeeMasterAuthRemark,
                        AddressDetailsEmployeeMasterAuth = a.AddressDetailsEmployeeMasterAuth,
                        UpdatedDate = a.UpdatedDate,
                        UpdatedBy = a.UpdatedBy
                    }).ToList(),

                    // Employment Details
                    EmploymentDetails = emp.EmployeeMasterEmploymentDetailEmploymentDetailsEmployeeMasters.Select(e => new EmployeeMasterEmploymentDTO
                    {
                        EmployeeMasterEmploymentDetailsId = e.EmployeeMasterEmploymentDetailsId,
                        //EmploymentDetailsEmployeeMasterId = e.EmploymentDetailsEmployeeMasterId,
                        //EmploymentDetailsDivisionId = e.EmploymentDetailsDivisionId,
                        //EmploymentDetailsPositionId = e.EmploymentDetailsPositionId,
                        EmployeeMasterFullName=e.EmploymentDetailsEmployeeMaster.EmployeeMasterFullName,
                       DivisionName=e.EmploymentDetailsDivision.DivisionName,
                       PositionMasterName=e.EmploymentDetailsPosition.PositionMasterName,
                        EmploymentDetailsOfferLetterId = e.EmploymentDetailsOfferLetterId,
                        //EmploymentDetailsEmployeeTypeId = e.EmploymentDetailsEmployeeTypeId,
                        //EmploymentDetailsParentCompanyId = e.EmploymentDetailsParentCompanyId,
                        EmployeeTypeName=e.EmploymentDetailsEmployeeType.EmployeeTypeName,
                        ParentCompanyName=e.EmploymentDetailsParentCompany.CompanyName,
                        EmploymentDetailsCompanyEntityId = e.EmploymentDetailsCompanyEntityId,
                        //EmploymentDetailsProfitcenterId = e.EmploymentDetailsProfitcenterId,
                        //EmploymentDetailsDepartmentId = e.EmploymentDetailsDepartmentId,
                        //EmploymentDetailsWorkastationId = e.EmploymentDetailsWorkastationId,
                        //EmploymentDetailsGradeId = e.EmploymentDetailsGradeId,
                        //EmploymentDetailsDesignationId = e.EmploymentDetailsDesignationId,
                        ProfitCenterName=e.EmploymentDetailsProfitcenter.ProfitCenterName,
                        DepartmentName=e.EmploymentDetailsDepartment.DepartmentName,
                        WorkStationName = e.EmploymentDetailsWorkastation.WorkStationName,
                        GradeName=e.EmploymentDetailsGrade.GradeName,
                        DesignationName=e.EmploymentDetailsDesignation.DesignationName,
                        EmploymentDetailsReportToId = e.EmploymentDetailsReportToId,
                        EmploymentDetailsReportDepartmentHodid = e.EmploymentDetailsReportDepartmentHodid,
                        EmploymentDetailsRemark = e.EmploymentDetailsRemark,
                        EmploymentDetailsAuth1Remark = e.EmploymentDetailsAuth1Remark,
                        EmploymentDetailsAuth2Remark = e.EmploymentDetailsAuth2Remark,
                        EmploymentDetailsAuth3Remark = e.EmploymentDetailsAuth3Remark,
                        EmploymentDetailsAuth1 = e.EmploymentDetailsAuth1,
                        EmploymentDetailsAuth2 = e.EmploymentDetailsAuth2,
                        EmploymentDetailsAuth3 = e.EmploymentDetailsAuth3,
                        UpdatedDate = e.UpdatedDate,
                        UpdatedBy = e.UpdatedBy
                    }).ToList()
                })
                .ToListAsync();

            return result;
        }

        public async Task<EmployeeMasterDTO?> GetEmployeeMasterById(int employeeMasterId)
        {
            if (employeeMasterId <= 0)
                throw new ArgumentException("EmployeeMasterId must be valid.", nameof(employeeMasterId));

            var employee = await dbContext.EmployeeMasterPersonalDetails
                .Where(e => e.EmployeeMasterId == employeeMasterId && e.EmployeeMasterIsActive)
                .Select(e => new EmployeeMasterDTO
                {
                    EmployeeMasterId = e.EmployeeMasterId,
                    EmployeeMasterCode = e.EmployeeMasterCode,
                    EmployeeMasterFirstName = e.EmployeeMasterFirstName,
                    EmployeeMasterMiddleName = e.EmployeeMasterMiddleName,
                    EmployeeMasterLastName = e.EmployeeMasterLastName,
                    EmployeeMasterFullName = e.EmployeeMasterFullName,
                    EmployeeMasterDateOfBirth = e.EmployeeMasterDateOfBirth,
                    EmployeeMasterGender = e.EmployeeMasterGender,
                   // EmployeeMasterNationalityCountryId = e.EmployeeMasterNationalityCountryId,
                   CountryName=e.EmployeeMasterNationalityCountry.CountryName,
                    EmployeeMasterReligion = e.EmployeeMasterReligion,
                    EmployeeMasterReligionCategory = e.EmployeeMasterReligionCategory,
                    EmployeeMasterBloodGroup = e.EmployeeMasterBloodGroup,
                    EmployeeMasterPhotoAttachment = e.EmployeeMasterPhotoAttachment,
                    EmployeeMasterRemark = e.EmployeeMasterRemark,
                    EmployeeMasterAuthRemark = e.EmployeeMasterAuthRemark,
                    EmployeeMasterAuth = e.EmployeeMasterAuth,
                    EmployeeMasterIsDiscard = e.EmployeeMasterIsDiscard,
                    EmployeeMasterIsActive = e.EmployeeMasterIsActive,
                    CreatedBy = e.CreatedBy,
                    CreatedDate = e.CreatedDate,
                    UpdatedBy = e.UpdatedBy,
                    UpdatedDate = e.UpdatedDate,

                   

                    // Address Details
                    AddressDetails = e.EmployeeMasterAddressDetails
                        .Where(a => a.AddressDetailsEmployeeMasterAuth) // optional active filter
                        .Select(a => new EmployeeMasterAddressDTO
                        {
                            EmployeeMasterAddressDetailsId = a.EmployeeMasterAddressDetailsId,
                            // AddressDetailsEmployeeMasterId = a.AddressDetailsEmployeeMasterId,
                            EmployeeMasterFullName = a.AddressDetailsEmployeeMaster.EmployeeMasterFullName,
                            AddressDetailsEmployeeMasterPresentAdress = a.AddressDetailsEmployeeMasterPresentAdress,
                            //AddressDetailsEmployeeMasterPresentCountryId = a.AddressDetailsEmployeeMasterPresentCountryId,
                            //AddressDetailsEmployeeMasterPresentStateId = a.AddressDetailsEmployeeMasterPresentStateId,
                            //AddressDetailsEmployeeMasterPresentDistrictId = a.AddressDetailsEmployeeMasterPresentDistrictId,
                            //AddressDetailsEmployeeMasterPresentCitytId = a.AddressDetailsEmployeeMasterPresentCitytId,
                            //AddressDetailsEmployeeMasterPresentPinCode = a.AddressDetailsEmployeeMasterPresentPinCode,
                            CountryName = a.AddressDetailsEmployeeMasterPermanantCountry.CountryName,
                            StateName = a.AddressDetailsEmployeeMasterPermanantState.StateName,
                            DistrictName = a.AddressDetailsEmployeeMasterPresentDistrict.DistrictName,
                            CityName = a.AddressDetailsEmployeeMasterPermanantCity.CityName,
                            AddressDetailsEmployeeMasterPemanantAddresssameAsPresent = a.AddressDetailsEmployeeMasterPemanantAddresssameAsPresent,
                            AddressDetailsEmployeeMasterPermanantAdress = a.AddressDetailsEmployeeMasterPermanantAdress,
                            AddressDetailsEmployeeMasterPermanantCountryId = a.AddressDetailsEmployeeMasterPermanantCountryId,
                            AddressDetailsEmployeeMasterPermanantStateId = a.AddressDetailsEmployeeMasterPermanantStateId,
                            AddressDetailsEmployeeMasterPermanantDistrictId = a.AddressDetailsEmployeeMasterPermanantDistrictId,
                            AddressDetailsEmployeeMasterPermanantCityId = a.AddressDetailsEmployeeMasterPermanantCityId,
                            AddressDetailsEmployeeMasterPermanantPinCode = a.AddressDetailsEmployeeMasterPermanantPinCode,
                            AddressDetailsEmployeeMasterAuthRemark = a.AddressDetailsEmployeeMasterAuthRemark,
                            AddressDetailsEmployeeMasterAuth = a.AddressDetailsEmployeeMasterAuth,
                            UpdatedDate = a.UpdatedDate,
                            UpdatedBy = a.UpdatedBy
                        }).ToList(),

                    // Family Details
                    FamilyDetails = e.EmployeeMasterFamilyDetails
                        .Where(f => f.FamilyDetailsEmployeeMasterAuth) // optional active filter
                        .Select(f => new EmployeeMasterFamilyDTO
                        {
                            EmployeeMasterFamilyDetailsId = f.EmployeeMasterFamilyDetailsId,
                            //FamilyDetailsEmployeeMasterId = f.FamilyDetailsEmployeeMasterId,
                            EmployeeMasterFullName=f.FamilyDetailsEmployeeMaster.EmployeeMasterFullName,
                            FamilyDetailsEmployeeMasterFatherHusbandName = f.FamilyDetailsEmployeeMasterFatherHusbandName,
                            FamilyDetailsEmployeeMasterMotherName = f.FamilyDetailsEmployeeMasterMotherName,
                            FamilyDetailsEmployeeMasterMartialStatus = f.FamilyDetailsEmployeeMasterMartialStatus,
                            FamilyDetailsEmployeeMasterSpouseName = f.FamilyDetailsEmployeeMasterSpouseName,
                            FamilyDetailsEmployeeMasterSpouseDateOfBirth = f.FamilyDetailsEmployeeMasterSpouseDateOfBirth,
                            FamilyDetailsEmployeeMasterSpouseAadharNumber = f.FamilyDetailsEmployeeMasterSpouseAadharNumber,
                            FamilyDetailsEmployeeMasterNumberofChidren = f.FamilyDetailsEmployeeMasterNumberofChidren,
                            FamilyDetailsEmployeeMasterSpouseAadharNumberAttachment = f.FamilyDetailsEmployeeMasterSpouseAadharNumberAttachment,
                            FamilyDetailsEmployeeMasterRemark = f.FamilyDetailsEmployeeMasterRemark,
                            FamilyDetailsEmployeeMasterAuthRemark = f.FamilyDetailsEmployeeMasterAuthRemark,
                            FamilyDetailsEmployeeMasterAuth = f.FamilyDetailsEmployeeMasterAuth,
                            UpdatedDate = f.UpdatedDate,
                            UpdatedBy = f.UpdatedBy
                        }).ToList(),

                    // Employment Details
                    EmploymentDetails = e.EmployeeMasterEmploymentDetailEmploymentDetailsEmployeeMasters
                        .Where(emp => emp.EmploymentDetailsAuth1) // optional active filter
                        .Select(emp => new EmployeeMasterEmploymentDTO
                        {
                            EmployeeMasterEmploymentDetailsId = emp.EmployeeMasterEmploymentDetailsId,
                            //EmploymentDetailsEmployeeMasterId = emp.EmploymentDetailsEmployeeMasterId,
                           EmployeeMasterFullName=emp.EmploymentDetailsEmployeeMaster.EmployeeMasterFullName,
                            DivisionName=emp.EmploymentDetailsDivision.DivisionName,
                            //EmploymentDetailsDivisionId = emp.EmploymentDetailsDivisionId,
                            PositionMasterName=emp.EmploymentDetailsPosition.PositionMasterName,
                            //EmploymentDetailsPositionId = emp.EmploymentDetailsPositionId,
                            EmploymentDetailsOfferLetterId = emp.EmploymentDetailsOfferLetterId,
                            //EmploymentDetailsEmployeeTypeId = emp.EmploymentDetailsEmployeeTypeId,
                            //EmploymentDetailsParentCompanyId = emp.EmploymentDetailsParentCompanyId,
                            EmployeeTypeName=emp.EmploymentDetailsEmployeeType.EmployeeTypeName,
                            ParentCompanyName=emp.EmploymentDetailsParentCompany.CompanyName,
                            EmploymentDetailsCompanyEntityId = emp.EmploymentDetailsCompanyEntityId,
                            //EmploymentDetailsProfitcenterId = emp.EmploymentDetailsProfitcenterId,
                            //EmploymentDetailsDepartmentId = emp.EmploymentDetailsDepartmentId,
                            //EmploymentDetailsWorkastationId = emp.EmploymentDetailsWorkastationId,
                            //EmploymentDetailsGradeId = emp.EmploymentDetailsGradeId,
                            //EmploymentDetailsDesignationId = emp.EmploymentDetailsDesignationId,
                            ProfitCenterName=emp.EmploymentDetailsProfitcenter.ProfitCenterName,
                            DepartmentName=emp.EmploymentDetailsDepartment.DepartmentName,
                            WorkStationName = emp.EmploymentDetailsWorkastation.WorkStationName,
                            GradeName=emp.EmploymentDetailsGrade.GradeName,
                            EmploymentDetailsReportToId = emp.EmploymentDetailsReportToId,
                            EmploymentDetailsReportDepartmentHodid = emp.EmploymentDetailsReportDepartmentHodid,
                            EmploymentDetailsRemark = emp.EmploymentDetailsRemark,
                            EmploymentDetailsAuth1Remark = emp.EmploymentDetailsAuth1Remark,
                            EmploymentDetailsAuth2Remark = emp.EmploymentDetailsAuth2Remark,
                            EmploymentDetailsAuth3Remark = emp.EmploymentDetailsAuth3Remark,
                            EmploymentDetailsAuth1 = emp.EmploymentDetailsAuth1,
                            EmploymentDetailsAuth2 = emp.EmploymentDetailsAuth2,
                            EmploymentDetailsAuth3 = emp.EmploymentDetailsAuth3,
                            UpdatedDate = emp.UpdatedDate,
                            UpdatedBy = emp.UpdatedBy
                        }).ToList()
                })
                .FirstOrDefaultAsync();

            return employee;
        }


        public async Task UpdateEmployeeMasterAsync(UpdateEmployeeMasterRequest request)
        {
            if (request.EmployeeMasterId <= 0)
                throw new ArgumentException("EmployeeMasterId must be valid.", nameof(request.EmployeeMasterId));

            using var transaction = await dbContext.Database.BeginTransactionAsync();
            try
            {
                // 1️⃣ Retrieve existing Employee Master record
                var employee = await dbContext.EmployeeMasterPersonalDetails
                    .FirstOrDefaultAsync(e => e.EmployeeMasterId == request.EmployeeMasterId);

                if (employee == null)
                    throw new KeyNotFoundException($"Employee with ID {request.EmployeeMasterId} not found.");

                // 2️⃣ Update master properties
                employee.EmployeeMasterCode = request.EmployeeMasterCode;
                employee.EmployeeMasterFirstName = request.EmployeeMasterFirstName;
                employee.EmployeeMasterMiddleName = request.EmployeeMasterMiddleName;
                employee.EmployeeMasterLastName = request.EmployeeMasterLastName;
                employee.EmployeeMasterFullName = request.EmployeeMasterFullName;
                employee.EmployeeMasterDateOfBirth = request.EmployeeMasterDateOfBirth;
                employee.EmployeeMasterGender = request.EmployeeMasterGender;
                employee.EmployeeMasterNationalityCountryId = request.EmployeeMasterNationalityCountryId;
                employee.EmployeeMasterReligion = request.EmployeeMasterReligion;
                employee.EmployeeMasterReligionCategory = request.EmployeeMasterReligionCategory;
                employee.EmployeeMasterBloodGroup = request.EmployeeMasterBloodGroup;
                employee.EmployeeMasterPhotoAttachment = request.EmployeeMasterPhotoAttachment;
                employee.EmployeeMasterRemark = request.EmployeeMasterRemark;
                employee.EmployeeMasterAuthRemark = request.EmployeeMasterAuthRemark;
                employee.EmployeeMasterAuth = request.EmployeeMasterAuth;
                employee.EmployeeMasterIsDiscard = request.EmployeeMasterIsDiscard;
                employee.EmployeeMasterIsActive = request.EmployeeMasterIsActive;
                employee.UpdatedBy = request.UpdatedBy;
                employee.UpdatedDate = request.UpdatedDate;

                // 3️⃣ Update existing Family Details
                if (request.FamilyDetails != null && request.FamilyDetails.Any())
                {
                    foreach (var f in request.FamilyDetails)
                    {
                        var existingFamily = await dbContext.EmployeeMasterFamilyDetails
                            .FirstOrDefaultAsync(x => x.FamilyDetailsEmployeeMasterId == request.EmployeeMasterId
                                                      && x.FamilyDetailsEmployeeMasterFatherHusbandName == f.FamilyDetailsEmployeeMasterFatherHusbandName);
                        if (existingFamily != null)
                        {
                            // Update only existing records
                            existingFamily.FamilyDetailsEmployeeMasterMotherName = f.FamilyDetailsEmployeeMasterMotherName;
                            existingFamily.FamilyDetailsEmployeeMasterMartialStatus = f.FamilyDetailsEmployeeMasterMartialStatus;
                            existingFamily.FamilyDetailsEmployeeMasterSpouseName = f.FamilyDetailsEmployeeMasterSpouseName;
                            existingFamily.FamilyDetailsEmployeeMasterSpouseDateOfBirth = f.FamilyDetailsEmployeeMasterSpouseDateOfBirth;
                            existingFamily.FamilyDetailsEmployeeMasterSpouseAadharNumber = f.FamilyDetailsEmployeeMasterSpouseAadharNumber;
                            existingFamily.FamilyDetailsEmployeeMasterNumberofChidren = f.FamilyDetailsEmployeeMasterNumberofChidren;
                            existingFamily.FamilyDetailsEmployeeMasterSpouseAadharNumberAttachment = f.FamilyDetailsEmployeeMasterSpouseAadharNumberAttachment;
                            existingFamily.FamilyDetailsEmployeeMasterRemark = f.FamilyDetailsEmployeeMasterRemark;
                            existingFamily.FamilyDetailsEmployeeMasterAuthRemark = f.FamilyDetailsEmployeeMasterAuthRemark;
                            existingFamily.FamilyDetailsEmployeeMasterAuth = f.FamilyDetailsEmployeeMasterAuth;
                            existingFamily.UpdatedBy = f.UpdatedBy;
                            existingFamily.UpdatedDate = f.UpdatedDate;
                        }
                    }
                }

                // 4️⃣ Update existing Address Details
                if (request.AddressDetails != null && request.AddressDetails.Any())
                {
                    foreach (var a in request.AddressDetails)
                    {
                        var existingAddress = await dbContext.EmployeeMasterAddressDetails
                            .FirstOrDefaultAsync(x => x.AddressDetailsEmployeeMasterId == request.EmployeeMasterId
                                                      && x.AddressDetailsEmployeeMasterPresentAdress == a.AddressDetailsEmployeeMasterPresentAdress);
                        if (existingAddress != null)
                        {
                            existingAddress.AddressDetailsEmployeeMasterPresentCountryId = a.AddressDetailsEmployeeMasterPresentCountryId;
                            existingAddress.AddressDetailsEmployeeMasterPresentStateId = a.AddressDetailsEmployeeMasterPresentStateId;
                            existingAddress.AddressDetailsEmployeeMasterPresentDistrictId = a.AddressDetailsEmployeeMasterPresentDistrictId;
                            existingAddress.AddressDetailsEmployeeMasterPresentCitytId = a.AddressDetailsEmployeeMasterPresentCitytId;
                            existingAddress.AddressDetailsEmployeeMasterPresentPinCode = a.AddressDetailsEmployeeMasterPresentPinCode;
                            existingAddress.AddressDetailsEmployeeMasterPemanantAddresssameAsPresent = a.AddressDetailsEmployeeMasterPemanantAddresssameAsPresent;
                            existingAddress.AddressDetailsEmployeeMasterPermanantAdress = a.AddressDetailsEmployeeMasterPermanantAdress;
                            existingAddress.AddressDetailsEmployeeMasterPermanantCountryId = a.AddressDetailsEmployeeMasterPermanantCountryId;
                            existingAddress.AddressDetailsEmployeeMasterPermanantStateId = a.AddressDetailsEmployeeMasterPermanantStateId;
                            existingAddress.AddressDetailsEmployeeMasterPermanantDistrictId = a.AddressDetailsEmployeeMasterPermanantDistrictId;
                            existingAddress.AddressDetailsEmployeeMasterPermanantCityId = a.AddressDetailsEmployeeMasterPermanantCityId;
                            existingAddress.AddressDetailsEmployeeMasterPermanantPinCode = a.AddressDetailsEmployeeMasterPermanantPinCode;
                            existingAddress.AddressDetailsEmployeeMasterAuthRemark = a.AddressDetailsEmployeeMasterAuthRemark;
                            existingAddress.AddressDetailsEmployeeMasterAuth = a.AddressDetailsEmployeeMasterAuth;
                            existingAddress.UpdatedBy = a.UpdatedBy;
                            existingAddress.UpdatedDate = a.UpdatedDate;
                        }
                    }
                }

                // 5️⃣ Update existing Employment Details
                if (request.EmploymentDetails != null && request.EmploymentDetails.Any())
                {
                    foreach (var e in request.EmploymentDetails)
                    {
                        var existingEmployment = await dbContext.EmployeeMasterEmploymentDetails
                            .FirstOrDefaultAsync(x => x.EmploymentDetailsEmployeeMasterId == request.EmployeeMasterId
                                                      && x.EmploymentDetailsPositionId == e.EmploymentDetailsPositionId);
                        if (existingEmployment != null)
                        {
                            existingEmployment.EmploymentDetailsDivisionId = e.EmploymentDetailsDivisionId;
                            existingEmployment.EmploymentDetailsOfferLetterId = e.EmploymentDetailsOfferLetterId;
                            existingEmployment.EmploymentDetailsEmployeeTypeId = e.EmploymentDetailsEmployeeTypeId;
                            existingEmployment.EmploymentDetailsParentCompanyId = e.EmploymentDetailsParentCompanyId;
                            existingEmployment.EmploymentDetailsCompanyEntityId = e.EmploymentDetailsCompanyEntityId;
                            existingEmployment.EmploymentDetailsProfitcenterId = e.EmploymentDetailsProfitcenterId;
                            existingEmployment.EmploymentDetailsDepartmentId = e.EmploymentDetailsDepartmentId;
                            existingEmployment.EmploymentDetailsWorkastationId = e.EmploymentDetailsWorkastationId;
                            existingEmployment.EmploymentDetailsGradeId = e.EmploymentDetailsGradeId;
                            existingEmployment.EmploymentDetailsDesignationId = e.EmploymentDetailsDesignationId;
                            existingEmployment.EmploymentDetailsReportToId = e.EmploymentDetailsReportToId;
                            existingEmployment.EmploymentDetailsReportDepartmentHodid = e.EmploymentDetailsReportDepartmentHodid;
                            existingEmployment.EmploymentDetailsRemark = e.EmploymentDetailsRemark;
                            existingEmployment.EmploymentDetailsAuth1Remark = e.EmploymentDetailsAuth1Remark;
                            existingEmployment.EmploymentDetailsAuth2Remark = e.EmploymentDetailsAuth2Remark;
                            existingEmployment.EmploymentDetailsAuth3Remark = e.EmploymentDetailsAuth3Remark;
                            existingEmployment.EmploymentDetailsAuth1 = e.EmploymentDetailsAuth1;
                            existingEmployment.EmploymentDetailsAuth2 = e.EmploymentDetailsAuth2;
                            existingEmployment.EmploymentDetailsAuth3 = e.EmploymentDetailsAuth3;
                            existingEmployment.UpdatedBy = e.UpdatedBy;
                            existingEmployment.UpdatedDate = e.UpdatedDate;
                        }
                    }
                }

                // 6️⃣ Save all changes
                await dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

    }
}
