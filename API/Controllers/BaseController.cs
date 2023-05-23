using AutoMapper;
using Bussines.DTO;
using Bussines.Service.Concrete;
using Domain.Entities;
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
        private readonly IMapper _mapper;
        public BaseController(IMediaService mediaService, IProductService productService)
        {
            _mediaService = mediaService;
            _productService = productService;
        }
        [HttpPost("/product")]
        public async Task<ActionResult<bool>> createdProduct([FromForm] ProductDTO productDTO)
        {
            try
            {
                var result =await _productService.SaveProduct(productDTO);
                return Ok(result);  
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
            
        }
        
    }
}
