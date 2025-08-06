using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KalaGenset.ERP.HR.Data.Models;
using KalaGenset.ERP.HR.Core.Request.ClassOfTravel;
using KalaGenset.ERP.HR.Core.Request.Grade;


namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IClassOfTravelMaster
    {
        /// <summary>
        /// Adds a new ClassOfTravel to the database.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task AddClassOfTravelAsync(InsertClassOfTravelRequest request);
        /// <summary>
        /// Updates an existing ClassOfTravel in the database.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task UpdateClassOfTravelAsync(UpdateClassOfTravelRequest request);
        /// <summary>
        /// Retrieves all ClassOfTravels from the database.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<ClassOfTravelMaster>> GetClassOfTravelDetailsAsync();
        /// <summary>
        /// Retrieves a ClassOfTravel by its ID from the database.
        /// </summary>
        /// <param name="ClassOfTravelId"></param>
        /// <returns></returns>
        public Task<ClassOfTravelMaster?> GetClassOfTravelById(int ClassOfTravelId);
        /// <summary>
        /// Deletes a ClassOfTravel by its ID from the database.
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public Task DeleteClassOfTravelAsync(int cid);
    }
}
