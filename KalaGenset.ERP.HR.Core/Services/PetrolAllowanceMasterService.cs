using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request;
using KalaGenset.ERP.HR.Data.DbContexts;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace KalaGenset.ERP.HR.Core.Services
{


    public class PetrolAllowanceMasterService : IPetrolAllowanceMaster

    {
        private readonly KalaDbContext _context;
        public PetrolAllowanceMasterService(KalaDbContext context)
        {
            _context = context;
        }

        public async Task AddPetrolAllowanceMasterAsync(InsertPetrolAllowanceMasterRequest InsertPetrolAllowanceMasterRequest)
        {
            try
            {
                var PetrolAllowance = new PetrolAllowanceMaster
                {           
                    TwoWheelerPerKm = InsertPetrolAllowanceMasterRequest.TwoWheelerPerKm,
                    FourWheelerPerKm = InsertPetrolAllowanceMasterRequest.FourWheelerPerKm,
                    PetrolAllowanceRemark = InsertPetrolAllowanceMasterRequest.PetrolAllowanceRemark,
                    PetrolAllowanceAuthRemark = InsertPetrolAllowanceMasterRequest.PetrolAllowanceAuthRemark,
                    PetrolAllowanceIsAuth = InsertPetrolAllowanceMasterRequest.PetrolAllowanceIsAuth,
                    PetrolAllowanceIsDiscard = InsertPetrolAllowanceMasterRequest.PetrolAllowanceIsDiscard,
                    PetrolAllowanceIsActive = InsertPetrolAllowanceMasterRequest.PetrolAllowanceIsActive,
                    CreatedBy = InsertPetrolAllowanceMasterRequest.CreatedBy,
                    CreatedDate = InsertPetrolAllowanceMasterRequest.CreatedDate,
                };
                await _context.PetrolAllowanceMasters.AddAsync(PetrolAllowance);
                await _context.SaveChangesAsync();

            }
            catch
            {
                throw; // Let the controller handle the error
            }
        }

        public async Task<IEnumerable<PetrolAllowanceMaster>> GetPetrolAllowance()
        {
            return await _context.PetrolAllowanceMasters.ToListAsync();
        }

        public async Task<PetrolAllowanceMaster> GetPetrolAllowanceTypeById(int PetrolAllowanceId)
        {
            return await _context.PetrolAllowanceMasters.FirstOrDefaultAsync(c => c.PetrolAllowanceId == PetrolAllowanceId);

        }
        public async Task UpdatePetrolAllowanceMasterService(UpdatePetrolAllowanceMasterRequest updatePetrolAllowanceMasterRequest)
        {
            try
            {
                var PetrolAllowance = await _context.PetrolAllowanceMasters.FirstOrDefaultAsync(c => c.PetrolAllowanceId == updatePetrolAllowanceMasterRequest.PetrolAllowanceId);

                PetrolAllowance.PetrolAllowanceId = updatePetrolAllowanceMasterRequest.PetrolAllowanceId;
                PetrolAllowance.TwoWheelerPerKm = updatePetrolAllowanceMasterRequest.TwoWheelerPerKm;
                PetrolAllowance.FourWheelerPerKm = updatePetrolAllowanceMasterRequest.FourWheelerPerKm;
                PetrolAllowance.PetrolAllowanceRemark = updatePetrolAllowanceMasterRequest.PetrolAllowanceRemark;
                PetrolAllowance.PetrolAllowanceAuthRemark = updatePetrolAllowanceMasterRequest.PetrolAllowanceAuthRemark;
                PetrolAllowance.PetrolAllowanceIsAuth = updatePetrolAllowanceMasterRequest.PetrolAllowanceIsAuth;
                PetrolAllowance.PetrolAllowanceIsDiscard = updatePetrolAllowanceMasterRequest.PetrolAllowanceIsDiscard;
                PetrolAllowance.PetrolAllowanceIsActive = updatePetrolAllowanceMasterRequest.PetrolAllowanceIsActive;
                PetrolAllowance.CreatedBy = updatePetrolAllowanceMasterRequest.CreatedBy;
                PetrolAllowance.CreatedDate = updatePetrolAllowanceMasterRequest.CreatedDate;

                _context.PetrolAllowanceMasters.Update(PetrolAllowance);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;

            }


        }
        public async Task DeletePetrolAllowanceById(int petrolallowanceId)
        {
            try
            {
                var PetrolAllowance = await _context.PetrolAllowanceMasters.FirstOrDefaultAsync(c => c.PetrolAllowanceId == petrolallowanceId);
                if (PetrolAllowance == null)
                {
                    throw new Exception("PetrolAllowance ID Not Found");
                }
                if(!PetrolAllowance.PetrolAllowanceIsActive)
                {
                    throw new Exception("Petrol Allowance alredy Deleted");
                }
                PetrolAllowance.PetrolAllowanceIsActive = false;
                _context.PetrolAllowanceMasters.Update(PetrolAllowance);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) 
            {
                throw;
            }
        }



    }        

 }  
