using CommunityCommuting_BAL.DTO;
using CommunityCommuting_BAL.Interface;
using CommunityCommuting_BAL.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoummunityCommutingProject1.Controllers
{
    [Route("api")]
    public class RideProvideController : Controller
    {
        private readonly IRideProvideService _service;
        private readonly IBillService _billService;
        private readonly ITripService _tripService;

        public RideProvideController(IRideProvideService service,IBillService billService, ITripService tripService)
        {
            _service = service;
            _billService = billService;
            _tripService = tripService;
        }

        //GET: api/<controller>/new
        [HttpPost("[controller]/new")]
        public async Task<IActionResult> createNewProvide([FromBody] RideProvideDTO rideProviderDTO)
        {
            try
            {
                Output result = await _service.CreateNewRideProvider(rideProviderDTO);
                if (result.Result == true)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(result.errorMessage);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("[controller]/{providerId}/update")]
        public async Task<IActionResult> updateRideProvide(string providerId, [FromBody] UpdateRideProvideDTO rideProviderDTO)
        {
            try
            {
                Output result = await _service.UpdateNewRideProvider(providerId, rideProviderDTO);
                if (result.Result == true)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(result.errorMessage);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("[controller]/billing/{month}")]
        public async Task<IActionResult> fetchBill(int month)
        {
            var res = await _billService.RetrieveBill(month);
            return Ok(res);
        }


        [HttpPost("[controller]/addbooking")]
        public async Task<IActionResult> getTrip([FromBody] TripBookingDTO tripBookingDTO)
        {
            try
            {
                Console.WriteLine(tripBookingDTO.NoOfSeat);
                Output result = await _tripService.CreateTrip(tripBookingDTO);
                if (result.Result == true)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(result.errorMessage);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("[controller]/bookingStatus/{tripId}")]
        public async Task<IActionResult> getTripDetails(string tripId)
        {
            var result = await _tripService.getTrip(tripId);
            return Ok(result);
        }


        [HttpPut("[controller]/bookings/{tripId}")]
        public async Task<IActionResult> updateDetails(string tripId, [FromBody] TripBookingDTO tripBookingDTO)
        {
            try
            {
                Output res = await _tripService.updateTrip(tripId, tripBookingDTO);
                if (res.Result == true)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(res.errorMessage);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("[controller]/bookings/{tripId}")]
        public async Task<IActionResult> deleteDetails(string tripId)
        {
            var res = await _tripService.deleteTrip(tripId);
            if (res.Result == true)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500, "Failed to delete trip details");
            }
        }


        [HttpGet("[controller]/generatebill/{tripId}")]
        public async Task<IActionResult> getBillDetailz(string tripId)
        {
            var result = await _billService.generateBillDetails(tripId);
            return Ok(result);
        }

        [HttpGet("[controller]/RiderDetails/{rpId}")]
        public async Task<IActionResult> GetRiderById(string rpId)
        {
            var result = await _service.GetRiderById(rpId);
            return Ok(result);
        }

        [HttpGet("[controller]/TripDetails/{tripId}")]
        public async Task<IActionResult> GetTripDetails(string tripId)
        {
            var result = await _tripService.getTrip(tripId);
            return Ok(result);
        }
    }
}
