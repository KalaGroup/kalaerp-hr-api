using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.KPADetail;
using KalaGenset.ERP.HR.Data.DbContexts;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Services
{
    public class KPADetailsServices : IKpadetail
    {
        private readonly KalaDbContext _context;
        public KPADetailsServices(KalaDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Insert KPA Detail
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Task InsertKPADetailAsync(InsertKpadetailRequest request)
        {
            try
            {
                var kpadetail = new Kpadetail
                {
                    SrNo = request.SrNo,
                    DetailsKpaid = request.DetailsKpaid,
                    KpadetailsDescription = request.KpadetailsDescription,
                };
                _context.Kpadetails.Add(kpadetail);
                return _context.SaveChangesAsync();
            }
            catch (Exception ex)// Catch any exception that occurs during the insert operation
            {
                throw new Exception($"An error occurred while inserting KPADetail: {ex.Message}");
            }
        }
        /// <summary>
        /// Delete KPA Detail by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task DeleteKPADetailAsync(int id)
        {
            try
            {
                var kpadetail = await _context.Kpadetails.FirstOrDefaultAsync(c => c.KpadetailsId == id);
                if (kpadetail == null)
                {
                    throw new Exception("KPADetail not found.");
                }
                _context.Kpadetails.Remove(kpadetail);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)// Catch any exception that occurs during the delete operation
            {
                throw new Exception($"An error occurred while deleting KPADetail: {ex.Message}");
            }
        }
        /// <summary>
        /// get all KPA Details
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Kpadetail>> GetAllKPADetailsAsync()
        {
          return await _context.Kpadetails.ToListAsync();
        }
        /// <summary>
        /// get KPA Detail by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Kpadetail> GetKPADetailByID(int id)
        {
           return await _context.Kpadetails.FirstOrDefaultAsync(c => c.KpadetailsId == id);
        }
        /// <summary>
        /// update KPA Detail
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Task UpdateKPADetailAsync(UpdateKpadetailRequest request)
        {
            try
            {
                var kpadetail = new Kpadetail
                {
                    KpadetailsId = request.KpadetailsId,
                    SrNo = request.SrNo,
                    DetailsKpaid = request.DetailsKpaid,
                    KpadetailsDescription = request.KpadetailsDescription,
                };
                _context.Kpadetails.Update(kpadetail);
                return _context.SaveChangesAsync();
            }
            catch (Exception ex)//exception
            {
                throw new Exception($"An error occurred while updating KPADetail: {ex.Message}");
            }
        }
    }
}
