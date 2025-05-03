using ETrade.Cargo.BusinessLayer.Abstract;
using ETrade.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using ETrade.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _operationService;

        public CargoOperationsController(ICargoOperationService operationService)
        {
            _operationService = operationService;
        }

        [HttpGet]
        public IActionResult CargoOperationList()
        {
            var values = _operationService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
        {
            CargoOperation cargoOperation = new CargoOperation
            {
                Barcode = createCargoOperationDto.Barcode,
                Description = createCargoOperationDto.Description,
                OperationDate = createCargoOperationDto.OperationDate,
            };

            _operationService.TInsert(cargoOperation);
            return Ok("Kargo Operasyonları başarıyla oluşturuldu");
        }
        [HttpDelete]
        public IActionResult CargoOperationDelete(int id)
        {
            _operationService.TDelete(id);
            return Ok("Kargo Operasyonları başarıyla silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoOperationById(int id)
        {
            var values = _operationService.TGetById(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
        {
            CargoOperation cargoOperation = new CargoOperation
            {
                Barcode = updateCargoOperationDto.Barcode,
                Description = updateCargoOperationDto.Description,
                CargoOperationId = updateCargoOperationDto.CargoOperationId,
                OperationDate = updateCargoOperationDto.OperationDate,
            };
            _operationService.TUpdate(cargoOperation);
            return Ok("Kargo Operasyonları Başarıyla güncellendi");
        }
    }
}
