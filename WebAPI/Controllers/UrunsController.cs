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
        [HttpGet]
        public IActionResult get()
        {
           var result=  _urunService.GetAll();
            return Ok(result.Data);
        }
        [HttpPost]
        public IActionResult add(Urun urun)
        {
             _urunService.Add(urun);
            return Ok("eklendi");
        }
    }
}
