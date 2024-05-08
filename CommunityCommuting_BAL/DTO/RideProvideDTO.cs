using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityCommuting_BAL.DTO
{
    public class RideProvideDTO
    {
        public DateOnly BirthDate {  get; set; }
        public long Adharcard {  get; set; }
        public string EmailId { get; set; }
        public long Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DlNo { get; set; }
        public DateOnly ValidUpto { get; set; }
    }
}
