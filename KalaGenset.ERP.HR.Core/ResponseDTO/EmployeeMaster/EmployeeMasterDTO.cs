using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.ResponseDTO.EmployeeMaster
{
    public class EmployeeMasterDTO
    {
        public int EmployeeMasterId { get; set; }

        public string EmployeeMasterCode { get; set; } = null!;

        public string EmployeeMasterFirstName { get; set; } = null!;

        public string EmployeeMasterMiddleName { get; set; } = null!;

        public string EmployeeMasterLastName { get; set; } = null!;

        public string EmployeeMasterFullName { get; set; } = null!;

        public DateTime EmployeeMasterDateOfBirth { get; set; }

        public string EmployeeMasterGender { get; set; } = null!;

        //public int EmployeeMasterNationalityCountryId { get; set; }
        public string CountryName { get; set; } = null!;

        public string EmployeeMasterReligion { get; set; } = null!;

        public string EmployeeMasterReligionCategory { get; set; } = null!;

        public string EmployeeMasterBloodGroup { get; set; } = null!;

        public string EmployeeMasterPhotoAttachment { get; set; } = null!;

        public string EmployeeMasterRemark { get; set; } = null!;

        public string EmployeeMasterAuthRemark { get; set; } = null!;

        public bool EmployeeMasterAuth { get; set; }

        public bool EmployeeMasterIsDiscard { get; set; }

        public bool EmployeeMasterIsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

      
        public List<EmployeeMasterAddressDTO> AddressDetails { get; set; }
        public List<EmployeeMasterFamilyDTO> FamilyDetails { get; set; }
        public List<EmployeeMasterEmploymentDTO> EmploymentDetails { get; set; }
    }
   
    public class EmployeeMasterAddressDTO
    {
        public int EmployeeMasterAddressDetailsId { get; set; }

        //public int AddressDetailsEmployeeMasterId { get; set; }
        public string EmployeeMasterFullName { get; set; } = null!;

        public string AddressDetailsEmployeeMasterPresentAdress { get; set; } = null!;

        //public int AddressDetailsEmployeeMasterPresentCountryId { get; set; }
        public string CountryName { get; set; } = null!;
        //public int AddressDetailsEmployeeMasterPresentStateId { get; set; }
        public string StateName { get; set; } = null!;

        //public int AddressDetailsEmployeeMasterPresentDistrictId { get; set; }
        public string DistrictName { get; set; } = null!;

        //public int AddressDetailsEmployeeMasterPresentCitytId { get; set; }
        public string CityName { get; set; } = null!;

        public int AddressDetailsEmployeeMasterPresentPinCode { get; set; }

        public bool AddressDetailsEmployeeMasterPemanantAddresssameAsPresent { get; set; }

        public string AddressDetailsEmployeeMasterPermanantAdress { get; set; } = null!;

        public int AddressDetailsEmployeeMasterPermanantCountryId { get; set; }
       
        public int AddressDetailsEmployeeMasterPermanantStateId { get; set; }

        public int AddressDetailsEmployeeMasterPermanantDistrictId { get; set; }

        public int AddressDetailsEmployeeMasterPermanantCityId { get; set; }

        public int AddressDetailsEmployeeMasterPermanantPinCode { get; set; }

        public string AddressDetailsEmployeeMasterAuthRemark { get; set; } = null!;

        public bool AddressDetailsEmployeeMasterAuth { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }
    }
    public class EmployeeMasterFamilyDTO
    {
        public int EmployeeMasterFamilyDetailsId { get; set; }

        //public int FamilyDetailsEmployeeMasterId { get; set; }
        public string EmployeeMasterFullName { get; set; } = null!;

        public string FamilyDetailsEmployeeMasterFatherHusbandName { get; set; } = null!;

        public string FamilyDetailsEmployeeMasterMotherName { get; set; } = null!;

        public string FamilyDetailsEmployeeMasterMartialStatus { get; set; } = null!;

        public string FamilyDetailsEmployeeMasterSpouseName { get; set; } = null!;

        public DateTime FamilyDetailsEmployeeMasterSpouseDateOfBirth { get; set; }

        public string FamilyDetailsEmployeeMasterSpouseAadharNumber { get; set; } = null!;

        public int FamilyDetailsEmployeeMasterNumberofChidren { get; set; }

        public string FamilyDetailsEmployeeMasterSpouseAadharNumberAttachment { get; set; } = null!;

        public string FamilyDetailsEmployeeMasterRemark { get; set; } = null!;

        public string FamilyDetailsEmployeeMasterAuthRemark { get; set; } = null!;

        public bool FamilyDetailsEmployeeMasterAuth { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }
    }
    public class EmployeeMasterEmploymentDTO
      {
        public int EmployeeMasterEmploymentDetailsId { get; set; }

        //public int EmploymentDetailsEmployeeMasterId { get; set; }
        public string EmployeeMasterFullName { get; set; } = null!;

        //public int EmploymentDetailsDivisionId { get; set; }
        public string DivisionName { get; set; } = null!;

        //public int EmploymentDetailsPositionId { get; set; }
        public string PositionMasterName { get; set; } = null!;

        public int EmploymentDetailsOfferLetterId { get; set; }


        //public int EmploymentDetailsEmployeeTypeId { get; set; }
        public string EmployeeTypeName { get; set; } = null!;

        //public int EmploymentDetailsParentCompanyId { get; set; }
        public string ParentCompanyName { get; set; } = null!;

        public int EmploymentDetailsCompanyEntityId { get; set; }


        //public int EmploymentDetailsProfitcenterId { get; set; }
        public string ProfitCenterName { get; set; } = null!;

        //public int EmploymentDetailsDepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!;

        //public int EmploymentDetailsWorkastationId { get; set; }
        public string WorkStationName { get; set; } = null!;

        //public int EmploymentDetailsGradeId { get; set; }
        public string GradeName { get; set; } = null!;

        //public int EmploymentDetailsDesignationId { get; set; }
        public string DesignationName { get; set; } = null!;

        public int EmploymentDetailsReportToId { get; set; }

        public int EmploymentDetailsReportDepartmentHodid { get; set; }

        public string EmploymentDetailsRemark { get; set; } = null!;

        public string EmploymentDetailsAuth1Remark { get; set; } = null!;

        public string EmploymentDetailsAuth2Remark { get; set; } = null!;

        public string EmploymentDetailsAuth3Remark { get; set; } = null!;

        public bool EmploymentDetailsAuth1 { get; set; }

        public bool EmploymentDetailsAuth2 { get; set; }

        public bool EmploymentDetailsAuth3 { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }
    }
}
