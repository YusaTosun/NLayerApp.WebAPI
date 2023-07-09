using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.NewFolder;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class ProductController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Product> _service;

        public ProductController(IMapper mapper, IService<Product> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet(Name = "GetAll")]

        public async Task<IActionResult> All()
        {
            var product = await _service.GetAllAsync();
            var productDtos = _mapper.Map<List<ProductDto>>(product);
            //return Ok(CustomResponseDto<List<ProductDto>>.Success(200, productDtos));
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productDtos));

        }
    }
}
