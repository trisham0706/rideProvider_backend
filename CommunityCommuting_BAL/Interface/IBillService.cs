using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityCommuting_BAL.DTO;
using CommunityCommuting_BAL.Result;
using CommunityCommuting_DAL.Models;
using CommuntiyCommuting_BAL.DTO;


namespace CommunityCommuting_BAL.Interface
{
    public interface IBillService
    {
        Task<BillDTO> RetrieveBill(int month);
        Task<List<BillDTOs>> generateBillDetails(string tripId);
    }
}
