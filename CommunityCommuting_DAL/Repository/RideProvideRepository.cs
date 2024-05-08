using CommunityCommuting_DAL.DBContext;
using CommunityCommuting_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityCommuting_DAL.Models;
using Microsoft.EntityFrameworkCore;
using CommunityCommuting_DAL.Interface;

namespace CommunityCommuting_DAL.Repository
{
    public class RideProvideRepository : IRideProvide
    {
        private readonly CommunityCommutingDbContext _context;

        public RideProvideRepository(CommunityCommutingDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddRider(RideProvide rideProvide)
        {
            try
            {
                await _context.RideProvides.AddAsync(rideProvide);
                int ret = await _context.SaveChangesAsync();

                return ret;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> UpdateRider(RideProvide rideProvide)
        {
            _context.Entry(rideProvide).State = EntityState.Modified;
            int ret = await _context.SaveChangesAsync();
            return ret;
        }

        public async Task<RideProvide?> FindRideProviderById(string rideProvideId)
        {
            try
            {
                var result = await _context.RideProvides.FindAsync(rideProvideId);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<RideProvide>> GetRiderDetails(string rpId)
        {
            var res = await (from x in _context.RideProvides where x.rpId == rpId select x).ToListAsync();
            return res;
        }
    }
}
