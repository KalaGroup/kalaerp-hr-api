using FluentValidation;
using KalaGenset.ERP.HR.Data.DbContexts;
using KalaGenset.ERP.HR.Core.Request.EmployeeMasterUpdationForMaster;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace KalaGenset.ERP.HR.Core.Validation.EmployeeMasterUpdationForMasterValidation
{
    public class UpdateEmployeeMasterUpdationForMasterValidator : AbstractValidator<UpdateEmployeeMasterUpdationForMasterRequest>
    {
        private readonly KalaDbContext context;
        public UpdateEmployeeMasterUpdationForMasterValidator(KalaDbContext context)
        {
            this.context = context;

            RuleFor(x => x.EmployeeMasterUpdationForName)
                .NotEmpty().WithMessage("Employee Master Updation For Name is required.")
                .MaximumLength(100).WithMessage("Employee Master Updation For Name cannot exceed 100 characters.")
                .Matches("^[a-zA-Z ]*$").WithMessage("Employee Master Updation For Name must not contain special characters.");

            RuleFor(x => x.EmployeeMasterUpdationForRemark)
                .NotEmpty().WithMessage("Employee Master Updation For Remark is required.")
                .MaximumLength(500).WithMessage("Employee Master Updation For Remark cannot exceed 500 characters.");
            RuleFor(x => x.EmployeeMasterUpdationForAuthRemark)
                .NotEmpty().WithMessage("Employee Master Updation For Auth Remark is required.")
                .MaximumLength(500).WithMessage("Employee Master Updation For Auth Remark cannot exceed 500 characters.");
            RuleFor(x => x.EmployeeMasterUpdationForAuth)
                .NotNull().WithMessage("Employee Master Updation For Auth is required.");
            RuleFor(x => x.EmployeeMasterUpdationForIsDiscard)
                .NotNull().WithMessage("Employee Master Updation For Is Discard is required.");
            RuleFor(x => x.EmployeeMasterUpdationForIsActive)
                .NotNull().WithMessage("Employee Master Updation For Is Active is required.");
           

            RuleFor(x => x.EmployeeMasterUpdationForId)
                .NotEmpty().WithMessage("Employee Master Updation For ID is required.")
                .GreaterThan(0).WithMessage("Employee Master Updation For ID must be a positive integer.")
                .MustAsync(async (id, cancellation) =>
                {
                    return await context.EmployeeMasterUpdationForMasters.AnyAsync(x => x.EmployeeMasterUpdationForId == id, cancellation);
                }).WithMessage("Employee Master Updation For ID does not exist.");
        }
    }
}
