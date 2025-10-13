using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.DivisionMaster;
using KalaGenset.ERP.HR.Data.DbContexts;

namespace KalaGenset.ERP.HR.Core.Validation.DivisionMasterValidation
{
    public class UpdateDivisionRequestValidator : AbstractValidator<UpdateDivisionMasterRequest>
    {
        private readonly KalaDbContext context;
        public UpdateDivisionRequestValidator(KalaDbContext context)
        {
            this.context = context;


            RuleFor(x => x.DivisionCode)
                .NotEmpty().WithMessage("Division Code is required.")
                .MaximumLength(10).WithMessage("Division Code cannot be longer than 10 characters.")
                .Matches("^[A-Za-z0-9]*$").WithMessage("Division Code must not contain special characters.");

            RuleFor(x => x.DivisionName)
                .NotEmpty().WithMessage("Division Name is required.")
                .MaximumLength(100).WithMessage("Division Name cannot be longer than 100 characters.")
                .Matches("^[a-zA-Z ]*$").WithMessage("Division Name must not contain special characters.");

            RuleFor(x => x.DivisionShortName)
                .NotEmpty().WithMessage("Division Short Name is required.")
                .MaximumLength(100).WithMessage("Division Short Name cannot be longer than 100 characters.")
                .Matches("^[a-zA-Z ]*$").WithMessage("Division Short Name must not contain special characters.");

            RuleFor(x => x.DivisionMailId)
                .NotEmpty().WithMessage("Division Mail ID is required.")
                .EmailAddress().WithMessage("Division Mail ID must be a valid email address.");

          
        }
    }
}
