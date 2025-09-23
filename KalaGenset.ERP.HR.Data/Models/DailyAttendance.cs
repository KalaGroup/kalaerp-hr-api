using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class DailyAttendance
{
    public int AttendanceId { get; set; }

    public int AttendanceEmployeeId { get; set; }

    public int AttendanceCompanyId { get; set; }

    public string AttendanceDate { get; set; } = null!;

    public int InTime { get; set; }

    public int OutTime { get; set; }

    public bool AttendanceShiftId { get; set; }

    public bool InTimeAuth { get; set; }

    public bool OutTimeAuth { get; set; }

    public int AttendanceStatus { get; set; }

    public string AttendanceRemark { get; set; } = null!;

    public string AttendanceInTimeAuthRemark { get; set; } = null!;

    public string AttendanceOutTimeAuthRemark { get; set; } = null!;

    public bool AttendanceIsDiscard { get; set; }

    public bool AttendanceIsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }

    public virtual CompanyMaster AttendanceCompany { get; set; } = null!;

    public virtual EmployeeMasterPersonalDetail AttendanceEmployee { get; set; } = null!;

    public virtual UserLogin CreatedByNavigation { get; set; } = null!;

    public virtual UserLogin UpdatedByNavigation { get; set; } = null!;
}
