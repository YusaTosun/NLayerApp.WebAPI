﻿using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Services;

namespace NLayer.WEB.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _services;

        public ProductController(IProductService services)
        {
            _services = services;
        }

        public async Task<IActionResult> Index()
        {
            var customResponse = await _services.GetProductWithCategory();
            return View(customResponse.Data);
        }
    }
}
