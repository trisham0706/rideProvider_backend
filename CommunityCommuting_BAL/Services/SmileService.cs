using CommunityCommuting_BAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityCommuting_DAL.Interface;
using CommunityCommuting_DAL;
using CommunityCommuting_BAL.DTO;
using CommunityCommuting_DAL.Models;

namespace CommunityCommuting_BAL.Service
{
    public class SmileService : ISmileService
    {
        private readonly ISmile _smileRepository;
        public SmileService(ISmile smileRepository)
        {
            _smileRepository = smileRepository;
        }
        public async Task<List<TripDTO>> GetSmile(int month, string rpId)
        {

            List<Smile> lists = await _smileRepository.RetrieveSmileBasedOnMonthAndProviderId(month, rpId);

            List<TripDTO> res = new List<TripDTO>();

            foreach (Smile smile in lists)
            {
                TripDTO trip = new TripDTO()
                {
                    month = month,
                    rpId = rpId,
                    source = smile.source,
                    destination = smile.destination,
                    occupancy = smile.occupancy
                };
                res.Add(trip);
            }

            return res;


        }
    }
}

