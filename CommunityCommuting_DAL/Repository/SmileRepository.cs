using CommunityCommuting_DAL.DBContext;
using CommunityCommuting_DAL.Interface;
using CommunityCommuting_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityCommuting_DAL
{
    public class SmileRepository : ISmile
    {
        private readonly CommunityCommutingDbContext _context;
        public SmileRepository(CommunityCommutingDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<int> AddSmile(Smile smile)
        {
            await _context.Smiles.AddAsync(smile);
            int res = await _context.SaveChangesAsync();
            return res;
        }
        public async Task<List<Smile>> RetrieveSmileBasedOnMonthAndProviderId(int month, string rpId)
        {
            var res = await (from x in _context.Smiles where x.month == month && x.rpId == rpId select x).ToListAsync();
            return res;
        }
    }
}
