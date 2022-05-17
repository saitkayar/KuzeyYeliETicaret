using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {

        IUrunImageService _urunImageService;

        public ImagesController(IUrunImageService urunImageService)
        {
            _urunImageService = urunImageService;
        }

        [HttpGet("GetAll")]

        public IActionResult GetAll()
        {
            return Ok(_urunImageService.GetAll());
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] UrunImage ımage)
        {
            var result = _urunImageService.Add(ımage.File, ımage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result); ;
        }
    }
}
