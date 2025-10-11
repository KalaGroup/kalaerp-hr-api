using KalaGenset.ERP.HR.Core.Request.ERPPageAssignmentRelationship;
using KalaGenset.ERP.HR.Core.Request.OfferLetter;
using KalaGenset.ERP.HR.Core.ResponseDTO.ActivityMaster;
using KalaGenset.ERP.HR.Core.ResponseDTO.ERPPageAssignmentRelationship;
using KalaGenset.ERP.HR.Core.ResponseDTO.OfferLetter;
using KalaGenset.ERP.HR.Core.ResponseDTO.ResponsibilitiesMaster;
using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IERPPageAssignmentRelationship
    {
        public Task AddERPPageAssignmentRelationshipAsync(InsertPageAssignmentRelationshipRequest request);
        public Task<IEnumerable<AssignmentRelationshipDTO>> GetAllERPPageAssignmentRelationshipAsync();
        public Task<ErppageAssignmentRelationship?> GetERPPageAssignmentRelationshipById(int ErppageAssignmentRelationshipId);
        public Task DeleteERPPageAssignmentRelationshipAsync(int ErppageAssignmentRelationshipId);
        public Task UpdateERPPageAssignmentRelationshipAsync(UpdatePageAssignmentRelationshipRequest request);
        public Task<IEnumerable<GetEPRPageAssignmentRelationshipDeatils>> GetERPPageDetailsByMsaterId(int masterId);
        public Task<List<PageAssignmentReleationshipDeatilsDTO>> GetAllERPPageAssignmentRelationshipDeatils();


        public Task<List<getDivisionIdandpagetittelDTO>> GetDivivsionIdandPageTittel();
    }
}
