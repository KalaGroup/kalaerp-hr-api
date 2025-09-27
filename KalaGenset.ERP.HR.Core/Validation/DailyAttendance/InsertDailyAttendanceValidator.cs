using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.DailyAttendance;
using KalaGenset.ERP.HR.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Validation.DailyAttendance
{
    public class InsertDailyAttendanceValidator:AbstractValidator<InsertDailyAttendanceRequest>
    {
        private readonly KalaDbContext _context;
        public InsertDailyAttendanceValidator(KalaDbContext context)
        {
            _context = context;

            RuleFor(x => x.AttendanceEmployeeId)
            .GreaterThan(0).WithMessage("EmployeeId must be greater than 0.");

            RuleFor(x => x.AttendanceCompanyId)
                .GreaterThan(0).WithMessage("CompanyId must be greater than 0.");

        

            RuleFor(x => x.AttendanceShiftId)
                .NotNull().WithMessage("ShiftId is required.");

        

        }
    }
}
