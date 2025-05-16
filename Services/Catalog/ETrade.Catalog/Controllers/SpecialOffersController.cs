using ETrade.Catalog.Dtos.SpecialOfferDtos;
using ETrade.Catalog.Services.SpecialOfferServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialOffersController : ControllerBase
    {
        private readonly ISpecialOfferService _SpecialOfferService;

        public SpecialOffersController(ISpecialOfferService specialOfferService)
        {
            _SpecialOfferService = specialOfferService;
        }

        [HttpGet]
        public async Task<IActionResult> SpecialOfferList()
        {
            var values = await _SpecialOfferService.GetAllSpecialOfferAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecialOfferById(string id)
        {
            var values = await _SpecialOfferService.GetByIdSpecialOfferAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _SpecialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);
            return Ok("Özel teklif başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            await _SpecialOfferService.DeleteSpecialOfferAsync(id);
            return Ok("Özel Teklif başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _SpecialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);
            return Ok("Özel Teklif başarıyla güncellendi");
        }
    }
}
