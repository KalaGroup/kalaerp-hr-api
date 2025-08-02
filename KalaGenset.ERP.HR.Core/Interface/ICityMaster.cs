using KalaGenset.ERP.HR.Core.Request.City;
using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface ICityMaster
    {
        public Task AddCityAsync(InsertCityRequest request);

        public Task UpdateCityAsync(UpdateCityRequest request);

        public Task<IEnumerable<CityMaster>> GetAllCompanyDetailsAsync();

        public Task<CityMaster?> GetCityByID(int CityId);

        public Task DeleteCompanyAsync(int CityId);

    }
}
