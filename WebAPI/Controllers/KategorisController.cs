using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategorisController : ControllerBase
    {
        private IKategoriService _kategoriService;

        public KategorisController(IKategoriService kategoriService)
        {
            _kategoriService = kategoriService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result=_kategoriService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            var result = _kategoriService.Get(a => a.KategoriID == id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest("hata");
            

        }
    }
}
