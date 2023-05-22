using Bussines.DTO;
using Bussines.Service.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly IMediaService _mediaService;
        private readonly IProductService _productService;
        public BaseController(IMediaService mediaService, IProductService productService)
        {
            _mediaService = mediaService;
            _productService = productService;
        }
        [HttpPost("/product")]
        public async Task<ActionResult<bool>> createdProduct(ProductDTO productDTO, IFormFile file)
        {
            return Ok(true);
        }
        
    }
}
