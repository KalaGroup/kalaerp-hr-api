using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.ResponseDTO.ResponsibilitiesMaster
{
    public class ResponsibilitiesResponseDTO
    {
        public int ResponsibilitiesId { get; set; }
        public string ResponsibilitiesGradeName { get; set; } = string.Empty;
        public string ResponsibilitiesDesignationName { get; set; } = string.Empty;
        public string ResponsibilitiesDivisionName { get; set; } = string.Empty;
        public string? ResponsibilitiesRemark { get; set; }
        public string? ResponsibilitiesType { get; set; }
        public string? ResponsibilitiesAuthRemark { get; set; }
        public bool ResponsibilitiesAuth { get; set; }
        public bool ResponsibilitiesIsDiscard { get; set; }
        public bool ResponsibilitiesIsActive { get; set; }
       
    }
}
