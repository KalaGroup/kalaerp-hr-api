using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.EmployeeMaster;
using KalaGenset.ERP.HR.Core.ResponseDTO.EmployeeMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace KalaGenset.ERP.HR.Core.Validation.EmployeeMaster
{
    public class InsertEmployeeMasterValidator : AbstractValidator<InsertEmployeeMasterRequest>
    {
        private readonly KalaDbContext _context;

        public InsertEmployeeMasterValidator(KalaDbContext context)
        {
            _context = context;


            RuleFor(x => x.EmployeeMasterCode)
                .NotEmpty().WithMessage("Employee code is required")
               
                .WithMessage("Employee code already exists");

            RuleFor(x => x.EmployeeMasterFirstName)
                .NotEmpty().WithMessage("First name is required")
                .Matches("^[a-zA-Z '-]+$").WithMessage("First name can only contain letters, spaces, hyphens, and apostrophes")
                .MaximumLength(50).WithMessage("First name cannot exceed 50 characters");

            RuleFor(x => x.EmployeeMasterMiddleName)
                .Matches("^[a-zA-Z '-]+$")
                .When(x => !string.IsNullOrEmpty(x.EmployeeMasterMiddleName))
                .WithMessage("Middle name can only contain letters, spaces, hyphens, and apostrophes")
                .MaximumLength(50).WithMessage("Middle name cannot exceed 50 characters");

            RuleFor(x => x.EmployeeMasterLastName)
                .NotEmpty().WithMessage("Last name is required")
                .Matches("^[a-zA-Z '-]+$").WithMessage("Last name can only contain letters, spaces, hyphens, and apostrophes")
                .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters");

            RuleFor(x => x.EmployeeMasterFullName)
                .NotEmpty().WithMessage("Full name is required")
                .Matches("^[a-zA-Z '-]+$").WithMessage("Full name can only contain letters, spaces, hyphens, and apostrophes")
                .MaximumLength(150).WithMessage("Full name cannot exceed 150 characters");

           
           
          

            

         

            
        }
    }

   
    public class EmployeeMasterAddressValidator : AbstractValidator<EmployeeMasterAddressDTO>
    {
        public EmployeeMasterAddressValidator()
        {
            RuleFor(x => x.AddressDetailsEmployeeMasterPresentAdress)
                .NotEmpty().WithMessage("Present address is required")
                .MaximumLength(250).WithMessage("Present address cannot exceed 250 characters");

           

            RuleFor(x => x.AddressDetailsEmployeeMasterPresentPinCode)
                .InclusiveBetween(100000, 999999).WithMessage("Present pin code must be a 6-digit number");

            RuleFor(x => x.AddressDetailsEmployeeMasterPermanantAdress)
                .NotEmpty().WithMessage("Permanent address is required")
                .MaximumLength(250).WithMessage("Permanent address cannot exceed 250 characters");

            

            RuleFor(x => x.AddressDetailsEmployeeMasterPermanantPinCode)
                .InclusiveBetween(100000, 999999).WithMessage("Permanent pin code must be a 6-digit number");

           
        }
    }

    // =========================================================
    // 🔹 FAMILY VALIDATOR
    // =========================================================
    public class EmployeeMasterFamilyValidator : AbstractValidator<EmployeeMasterFamilyDTO>
    {
        public EmployeeMasterFamilyValidator()
        {
            RuleFor(x => x.FamilyDetailsEmployeeMasterFatherHusbandName)
                .NotEmpty().WithMessage("Father/Husband name is required")
                .Matches("^[a-zA-Z '-]+$").WithMessage("Father/Husband name can only contain letters, spaces, hyphens, and apostrophes")
                .MaximumLength(150).WithMessage("Father/Husband name cannot exceed 150 characters");

            RuleFor(x => x.FamilyDetailsEmployeeMasterMotherName)
                .NotEmpty().WithMessage("Mother name is required")
                .Matches("^[a-zA-Z '-]+$").WithMessage("Mother name can only contain letters, spaces, hyphens, and apostrophes")
                .MaximumLength(150).WithMessage("Mother name cannot exceed 150 characters");

           

            RuleFor(x => x.FamilyDetailsEmployeeMasterSpouseName)
                .Matches("^[a-zA-Z '-]+$")
                .When(x => !string.IsNullOrEmpty(x.FamilyDetailsEmployeeMasterSpouseName))
                .WithMessage("Spouse name can only contain letters, spaces, hyphens, and apostrophes")
                .MaximumLength(150).WithMessage("Spouse name cannot exceed 150 characters");

            RuleFor(x => x.FamilyDetailsEmployeeMasterSpouseAadharNumber)
                .Matches("^[0-9]{12}$")
                .When(x => !string.IsNullOrEmpty(x.FamilyDetailsEmployeeMasterSpouseAadharNumber))
                .WithMessage("Spouse Aadhar number must be a 12-digit numeric value");

           

          
        }
    }

   
}
