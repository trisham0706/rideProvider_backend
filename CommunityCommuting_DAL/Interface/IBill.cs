using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityCommuting_DAL.Models;

namespace CommunityCommuting_DAL.Interface
{
    public interface IBill
    {
        Task<List<billMaster>> GetBill(int month);
        Task<List<billMaster>> GetBillDetils(string tripId);
    }
}
