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
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public BaseController(IMediaService mediaService, IProductService productService, IUserService userService)
        {
            _mediaService = mediaService;
            _productService = productService;
            _userService = userService;
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
        [HttpPost("/user")]
        public async Task<ActionResult<bool>> createdUser([FromForm] UserDTO userDTO)
        {
            try
            {
                var result = await _userService.SaveUser(userDTO);
                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }

        }

    }
}
