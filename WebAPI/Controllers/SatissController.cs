using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SatissController : ControllerBase
    {
        private readonly ISatisService _satisService;

        public SatissController(ISatisService satisService)
        {
            _satisService = satisService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_satisService.GetAll());
        }
        [HttpGet("Get")]
        public IActionResult Get(int id)
        {
            return Ok(_satisService.Get(p=>p.SatisID == id));
        }
    }
}
