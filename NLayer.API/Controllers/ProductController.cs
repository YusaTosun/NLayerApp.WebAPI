﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;
using NLayer.API.Filters;

namespace NLayer.API.Controllers
{
    
    public class ProductController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductService _service;

        public ProductController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _service = productService;
        }

        //[HttpGet("GetProductWithCategory")]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            return CreateActionResult(await _service.GetProductWithCategory());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var product = await _service.GetAllAsync();
            var productDtos = _mapper.Map<List<ProductDto>>(product);
            //return Ok(CustomResponseDto<List<ProductDto>>.Success(200, productDtos));
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productDtos));

        }

        //GET api/prodcuts/5
        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            var productDto = _mapper.Map<ProductDto>(product);
            //return Ok(CustomResponseDto<List<ProductDto>>.Success(200, productDtos));
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productDto));

        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var product = await _service.AddAsync(_mapper.Map<Product>(productDto));
            var productsDto = _mapper.Map<ProductDto>(product);
            //return Ok(CustomResponseDto<List<ProductDto>>.Success(200, productDtos));
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productsDto));

        }
        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
        {
            await _service.UpdateAsync(_mapper.Map<Product>(productUpdateDto));

            //return Ok(CustomResponseDto<List<ProductDto>>.Success(200, productDtos));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));

        }

        //DELETE api/prodcuts/5
        [HttpDelete()]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(_mapper.Map<Product>(product));

            //return Ok(CustomResponseDto<List<ProductDto>>.Success(200, productDtos));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));

        }
        


    }
}
