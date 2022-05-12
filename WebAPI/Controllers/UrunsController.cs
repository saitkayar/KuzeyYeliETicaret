using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrunsController : ControllerBase
    {
        private IUrunService _urunService;

        public UrunsController(IUrunService urunService)
        {
            _urunService = urunService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _urunService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
   
        }
        [HttpGet("GetbyId")]
        public IActionResult GetById(int id)
        {
            var result = _urunService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("GetbyDetay")]
        public IActionResult GetByDetay()
        {
            var result = _urunService.GetAllByDetay();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("Add")]
        public IActionResult Add(Urun urun)
        {
          var resuly=   _urunService.Add(urun);
            return Ok(resuly);
        }
    }
}
