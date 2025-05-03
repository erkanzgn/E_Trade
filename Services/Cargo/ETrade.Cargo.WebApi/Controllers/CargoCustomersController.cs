using ETrade.Cargo.BusinessLayer.Abstract;
using ETrade.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using ETrade.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _customerService;

        public CargoCustomersController(ICargoCustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        public IActionResult CargoCustomerList()
        {

            var values = _customerService.TGetAll();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoıCustomerById(int id)
        {
            var value = _customerService.TGetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer
            {
                Address = createCargoCustomerDto.Address,
                City = createCargoCustomerDto.City,
                District = createCargoCustomerDto.District,
                Email = createCargoCustomerDto.Email,
                Name = createCargoCustomerDto.Name,
                Surname = createCargoCustomerDto.Surname,
                Phone = createCargoCustomerDto.Phone,

            };
            _customerService.TInsert(cargoCustomer);
            return Ok("Kargo Müsteri Başarıyla Eklendi");
        }
        [HttpDelete]
        public IActionResult RemoveCargoCustomer(int id)
        {
            _customerService.TDelete(id);
            return Ok("Kargo Müşteri Başarıyla Silindi");
        }
        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer
            {
                Address = updateCargoCustomerDto.Address,
                City = updateCargoCustomerDto.City,
                District = updateCargoCustomerDto.District,
                Email = updateCargoCustomerDto.Email,
                Name = updateCargoCustomerDto.Name,
                Surname = updateCargoCustomerDto.Surname,
                Phone = updateCargoCustomerDto.Phone,
            };
            _customerService.TUpdate(cargoCustomer);
            return Ok("Kargo Müşteri Başarıyla Güncellendi");
        }
    }
}
