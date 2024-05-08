using CommunityCommuting_BAL.DTO;
using CommunityCommuting_BAL.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommunityCommutingProject1.Controllers
{
    [Route("api")]
    [ApiController]
    public class SmileController : ControllerBase
    {
        private readonly ISmileService _service;
        public SmileController(ISmileService service)
        {
            _service = service;
        }
        [HttpGet("[controller]/{month}/{rpId}")]
        public async Task<IActionResult> getSmile(int month, string rpId)
        {
            var res = await _service.GetSmile(month, rpId);
            return Ok(res);
        }
    }
}