using KalaGenset.ERP.HR.Core.Request.ERPPageDetails;
using KalaGenset.ERP.HR.Core.ResponseDTO.ERPPageDetails;
using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IERPPageDetails
    {
        /// <summary>
        /// Add a new ERP Page Details record to the system.
        /// </summary>
        /// <param name="request">The request object containing ERP Page Details information to insert.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task AddERPPageDetailsAsync(InsertERPPageDetailsRequest request);

        /// <summary>
        /// Delete an ERP Page Details record by its ID. 
        /// This marks the record as inactive or discarded instead of removing it physically from the database.
        /// </summary>
        /// <param name="Eid">The unique identifier of the ERP Page Details record.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task DeleteERPPageDetailsAsync(int Eid);

        /// <summary>
        /// Get the details of a specific ERP Page Details record by its ID.
        /// </summary>
        /// <param name="Eid">The unique identifier of the ERP Page Details record.</param>
        /// <returns>
        /// A task containing the ERP Page Details entity if found; otherwise, null.
        /// </returns>
        public Task<KalaErppageDetail?> GetERPPageDetailsByID(int Eid);

        /// <summary>
        /// Get the details of all ERP Page Details records in the system.
        /// </summary>
        /// <returns>
        /// A task containing a collection of ERPPageDetailsResponseDTO objects.
        /// </returns>
        public Task<IEnumerable<ERPPageDetailsResponseDTO>> GetERPPageDetailsAsync();

        /// <summary>
        /// Update the details of an existing ERP Page Details record.
        /// </summary>
        /// <param name="request">The request object containing the updated ERP Page Details information.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task UpdateERPPageDetailsAsync(UpdateERPPageDetailsRequest request);
    }
}

