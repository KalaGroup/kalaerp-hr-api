using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.ResponseDTO.CTC
{
    public class CTCStructureMasterResponseDTO
    {
        public int CtcstructureId { get; set; }
        public int? CtcmasterGradeId { get; set; }
        public string? GradeName { get; set; }
        public int? CtcmasterBasic { get; set; }
        public int? CtcmasterDa { get; set; }
        public int? CtcmasterHra { get; set; }
        public int? CtcmasterConvAllowance { get; set; }
        public int? CtcmasterCityCompensatoryAlowance { get; set; }
        public int? CtcmasterLeaveTravelAllowance { get; set; }
        public int? CtcmasterCarAllowance { get; set; }
        public int? CtcmasterFuelAllowance { get; set; }
        public int? CtcmasterDriverAllowance { get; set; }
        public int? CtcmasterMiscAllowance { get; set; }
        public int? CtcmasterGross { get; set; }
        public int? CtcmasterPfemployee { get; set; }
        public int? CtcmasterPt { get; set; }
        public int? CtcmasterEsic { get; set; }
        public int? CtcmasterPfemployer { get; set; }
        public int? CtcmasterMedicalInsurance { get; set; }
        public int? CtcmasterPerformanceKpa { get; set; }
        public int? CtcmasterGraduity { get; set; }
        public int? CtcmasterBonus { get; set; }
        public int? CtcmasterMlwf { get; set; }

    }
}
