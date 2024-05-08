using CommunityCommuting_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityCommuting_DAL.Interface
{
    public interface ISmile
    {
        Task<List<Smile>> RetrieveSmileBasedOnMonthAndProviderId(int month, string rpId);
    }
}

