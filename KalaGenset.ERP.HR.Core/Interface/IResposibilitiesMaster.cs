using KalaGenset.ERP.HR.Core.Request.ResposibilitiesMaster;
using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IResposibilitiesMaster
    {
        public Task AddResposibilitiesAsync(InsertResposibilitiesMasterRequest request); // Adds a new responsibility to the system
        public Task<IEnumerable<ResposibilitiesMaster>> GetResposibilitiesAsync(); // Retrieves a list of all responsibilities in the system
        public Task<ResposibilitiesMaster> GetResposibilitiesByIdAsync(int id); // Retrieves a specific responsibility by its ID
        public Task UpdateResposibilitiesAsync(UpdateResposibilitiesMasterRequest request); // Updates an existing responsibility in the system
        public Task DeleteResposibilitiesAsync(int id); // Deletes a responsibility from the system by its ID
    }
}
