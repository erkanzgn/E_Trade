using ETrade.DtoLayer.CatalogDtos.CategoryDtos;
using ETrade.WebUI.Services.CatalogServices.CategoryServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ETrade.WebUI.ViewComponents.UILayoutViewComponent
{
    public class _NavbarUILayoutComponentPartial:ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _NavbarUILayoutComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var values = await _categoryService.GetAllCategoryAsync();
                return View(values);
            }
        }
    }
}
