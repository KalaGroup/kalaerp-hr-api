using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.EmployeeMaster;
using KalaGenset.ERP.HR.Core.ResponseDTO.EmployeeMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Validation.EmployeeMaster
{
    public class UpdateEmployeeMasterValidator : AbstractValidator<UpdateEmployeeMasterRequest>
    {
        private readonly KalaDbContext _context;
        public UpdateEmployeeMasterValidator(KalaDbContext context)
        {
            _context = context;

            // Employee code
            RuleFor(x => x.EmployeeMasterCode)
                .NotEmpty().WithMessage("Employee code is required");



            // First name
            RuleFor(x => x.EmployeeMasterFirstName)
                .NotEmpty().WithMessage("First name is required")
                 .Matches("^[a-zA-Z]+$")
                .MaximumLength(50).WithMessage("First name cannot exceed 50 characters");

            // Middle name (optional)
            RuleFor(x => x.EmployeeMasterMiddleName)
                 .Matches("^[a-zA-Z]+$")
                .MaximumLength(50).WithMessage("Middle name cannot exceed 50 characters");

            // Last name
            RuleFor(x => x.EmployeeMasterLastName)
                 .Matches("^[a-zA-Z]+$")
                .NotEmpty().WithMessage("Last name is required")
                .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters");

            // Full name
            RuleFor(x => x.EmployeeMasterFullName)
                .Matches("^[a-zA-Z '-]+$")
                .MaximumLength(150).WithMessage("Full name cannot exceed 150 characters");



            // Gender
            RuleFor(x => x.EmployeeMasterGender)
                .NotEmpty().WithMessage("Gender is required")
                .Must(g => g == "Male" || g == "Female" || g == "Other")
                .WithMessage("Gender must be Male, Female, or Other");

            // Nationality Country Id
            RuleFor(x => x.EmployeeMasterNationalityCountryId)
                .GreaterThan(0).WithMessage("Nationality Country is required");

            // Religion
            RuleFor(x => x.EmployeeMasterReligion)
                .NotEmpty().WithMessage("Religion is required")
                .MaximumLength(50).WithMessage("Religion cannot exceed 50 characters");

            // Religion category
            RuleFor(x => x.EmployeeMasterReligionCategory)
                .MaximumLength(50).WithMessage("Religion category cannot exceed 50 characters");

            // Blood group
            RuleFor(x => x.EmployeeMasterBloodGroup)
                .NotEmpty().WithMessage("Blood group is required")
                .Must(bg => new[] { "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-" }.Contains(bg))
                .WithMessage("Blood group must be a valid type");
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
}
    

