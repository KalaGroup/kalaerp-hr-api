using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KalaGenset.ERP.HR.Core.Request;
using KalaGenset.ERP.HR.Data.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IQualificationTypeMaster
    {
        public Task AddQualificationTypeMasterAsync(InsertQualificationTypeMasterRequest InsertQualificationTypeMasterRequest);
        public Task<IEnumerable<QualificationTypeMaster>> GetAllQualificationType();
        public Task<QualificationTypeMaster?> GetQualificationTypeById(int QualificationTypeID);
        public Task UpdateQualificationTypeMasterAsync(UpdateQualificationTypeMasterRequest UpdateQualificationTypeMasterRequest);
        public Task DeleteQualificationTypeById(int QualificationTypeId);
        
        }
} 
