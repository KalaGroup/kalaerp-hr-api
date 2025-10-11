using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.EmployeeMaster;
using KalaGenset.ERP.HR.Core.Request.ERPPageAssignmentRelationship;
using KalaGenset.ERP.HR.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Validation.ErppageAssignmentRelationship
{
    public class InsertERPPageValidator : AbstractValidator<InsertPageAssignmentRelationshipRequest>
    {
        private readonly KalaDbContext _context;

        public InsertERPPageValidator(KalaDbContext context)
        {
            _context = context;

            // Integer IDs should be greater than 0
            RuleFor(x => x.ErppageAssignmentRelationshipDivisionId)
                .GreaterThan(0).WithMessage("Division is required.");

            RuleFor(x => x.ErppageAssignmentRelationshipDepartmentId)
                .GreaterThan(0).WithMessage("Department is required.");

            RuleFor(x => x.ErppageAssignmentRelationshipProfitcenterId)
                .GreaterThan(0).WithMessage("Profit center is required.");

            // Remarks should not be empty and have max length
            RuleFor(x => x.ErppageAssignmentRelationshipRemark)
                .NotEmpty().WithMessage("Remark is required.")
                .MaximumLength(500).WithMessage("Remark cannot exceed 500 characters.");

            RuleFor(x => x.ErppageAssignmentRelationshipAuth1Remark)
                .NotEmpty().WithMessage("Auth1 Remark is required.")
                .MaximumLength(500).WithMessage("Auth1 Remark cannot exceed 500 characters.");

            RuleFor(x => x.ErppageAssignmentRelationshipAuth2Remark)
                .NotEmpty().WithMessage("Auth2 Remark is required.")
                .MaximumLength(500).WithMessage("Auth2 Remark cannot exceed 500 characters.");

        }
    }
}
