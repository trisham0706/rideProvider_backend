using CommunityCommuting_DAL.DBContext;
using CommunityCommuting_DAL.Interface;
using CommunityCommuting_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CommunityCommuting_DAL.Interface;

namespace CommunityCommuting_DAL
{
    public class BillRepository : IBill
    {
        private readonly CommunityCommutingDbContext _context;
        public BillRepository(CommunityCommutingDbContext context)
        {
            _context = context;
        }
        public async Task<List<billMaster>> GetBill(int month)
        {
            var res = await (from x in _context.billMasters where x.month == month select x).ToListAsync();
            return res;
        }
        public async Task<List<billMaster>> GetBillDetils(string tripId)
        {
            var res = await (from x in _context.billMasters where x.rideId == tripId select x).ToListAsync();
            return res;
        }
    }
}
