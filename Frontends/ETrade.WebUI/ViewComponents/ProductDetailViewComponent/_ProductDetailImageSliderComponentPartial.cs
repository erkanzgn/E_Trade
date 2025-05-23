﻿using ETrade.DtoLayer.CatalogDtos.ProductImageDtos;
using ETrade.WebUI.Services.CatalogServices.ProductImageServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ETrade.WebUI.ViewComponents.ProductDetailViewComponent
{
    public class _ProductDetailImageSliderComponentPartial : ViewComponent
    {

        private readonly IProductImageService _productImageService;

        public _ProductDetailImageSliderComponentPartial(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }


        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var dto = await _productImageService.GetByProductIdProductImageAsync(id);

            if (dto == null)
            {
                dto = new GetByIdProductImageDto
                {
                    Image1 = "/images/default.png",
                    Image2 = "/images/default.png",
                    Image3 = "/images/default.png",
                    Image4 = "/images/default.png"
                };
            }

            return View(dto);

        }

    }
}
