using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class RolesDetail
{
    public int RolesDetailsId { get; set; }

    public int DetailsRolesId { get; set; }

    public int SrNo { get; set; }

    public string RolesDetailsDescription { get; set; } = null!;

    public virtual RolesMaster DetailsRoles { get; set; } = null!;
}
