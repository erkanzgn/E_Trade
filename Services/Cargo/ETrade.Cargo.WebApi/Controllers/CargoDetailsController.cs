using ETrade.Cargo.BusinessLayer.Abstract;
using ETrade.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using ETrade.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var values = _cargoDetailService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            CargoDetail CargoDetail = new CargoDetail
            {
               Barcode = createCargoDetailDto.Barcode,
               CargoCompanyId=createCargoDetailDto.CargoCompanyId,
               ReciverCustomer=createCargoDetailDto.ReciverCustomer,
               SenderCustomer=createCargoDetailDto.SenderCustomer,

            };
            _cargoDetailService.TInsert(CargoDetail);
            return Ok("Kargo Detayları başarıyla oluşturuldu");
        }
        [HttpDelete]
        public IActionResult CargoDetailDelete(int id)
        {
            _cargoDetailService.TDelete(id);
            return Ok("Kargo Detayları başarıyla silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var values = _cargoDetailService.TGetById(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            CargoDetail CargoDetail = new CargoDetail
            {
                Barcode = updateCargoDetailDto.Barcode,
                CargoCompanyId = updateCargoDetailDto.CargoCompanyId,
                ReciverCustomer = updateCargoDetailDto.ReciverCustomer,
                SenderCustomer = updateCargoDetailDto.SenderCustomer,
                CargoDetailId=updateCargoDetailDto.CargoDetailId,
            };
            _cargoDetailService.TUpdate(CargoDetail);
            return Ok("Kargo Detayları Başarıyla güncellendi");
        }
    }
}
