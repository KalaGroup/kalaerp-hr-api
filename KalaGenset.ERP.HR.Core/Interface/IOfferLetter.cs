using KalaGenset.ERP.HR.Core.Request.LeaveTypeMaster;
using KalaGenset.ERP.HR.Core.Request.OfferLetter;
using KalaGenset.ERP.HR.Core.ResponseDTO.ActivityMaster;
using KalaGenset.ERP.HR.Core.ResponseDTO.LeaveTypeMaster;
using KalaGenset.ERP.HR.Core.ResponseDTO.OfferLetter;
using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IOfferLetter
    {
        public Task AddOfferLetterAsync(InsertOfferLetterRequest request);
        public Task<IEnumerable<OfferLetterWithDto>> GetAllOfferLetterAsync();
        public Task<OfferLetter?> GetOfferLetterById(int OfferLetterId);
        public Task DeleteOfferLetterAsync(int OfferLetterId);
        public Task UpdateOfferLetterAsync(UpdateOfferLetterRequest request);
    }
}
