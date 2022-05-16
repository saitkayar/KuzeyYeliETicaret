using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusterisController : ControllerBase
    {
        private IMusteriService _musteriService;

        public MusterisController(IMusteriService musteriService)
        {
            _musteriService = musteriService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_musteriService.GetAll());
        }
        [HttpGet("Get")]
        public IActionResult Get(int id)
        {
            return Ok(_musteriService.Get(p=>Convert.ToInt64( p.MusteriID)==id));
        }
    }
}
