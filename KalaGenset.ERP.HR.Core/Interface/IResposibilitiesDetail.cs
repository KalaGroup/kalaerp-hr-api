using KalaGenset.ERP.HR.Core.Request.ResposibilitiesDetail;
using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IResposibilitiesDetail
    {
        public Task AddResposibilitiesDetailAsync(InsertResposibilitiesDetailrequest request); // Adds a new responsibility detail to the system
        public Task<IEnumerable<ResposibilitiesDetail>> GetResposibilitiesDetailAsync(); // Retrieves a list of all responsibility details in the system
        public Task<ResposibilitiesDetail> GetResposibilitiesDetailByIdAsync(int id); // Retrieves a specific responsibility detail by its ID
        public Task UpdateResposibilitiesDetailAsync(UpdateResposibilitiesDetailRequest request); // Updates an existing responsibility detail in the system
        public Task DeleteResposibilitiesDetailAsync(int id); // Deletes a responsibility detail from the system by its ID

    }
}
