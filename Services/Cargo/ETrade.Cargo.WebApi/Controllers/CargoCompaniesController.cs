using ETrade.Cargo.BusinessLayer.Abstract;
using ETrade.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using ETrade.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompaniesController : ControllerBase
    {
        private readonly ICargoCompanyService _companyService;

        public CargoCompaniesController(ICargoCompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public IActionResult CargoCompanyList()
        {
            var values = _companyService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            CargoCompany cargoCompany = new CargoCompany
            {
                CargoCompanyName = createCargoCompanyDto.CargoCompanyName,
            };
            _companyService.TInsert(cargoCompany);
            return Ok("Kargo şirketi başarıyla oluşturuldu");
        }
        [HttpDelete]
        public IActionResult CargoCompanyDelete(int id)
        {
            _companyService.TDelete(id);
            return Ok("Kargo şirketi başarıyla silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoCompanyById(int id)
        {
            var values = _companyService.TGetById(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            CargoCompany cargoCompany = new CargoCompany
            {
                CargoCompanyId = updateCargoCompanyDto.CargoCompanyId,
                CargoCompanyName = updateCargoCompanyDto.CargoCompanyName
            };
            _companyService.TUpdate(cargoCompany);
            return Ok("Kargo Şirketi Başarıyla güncellendi");
        }
    }
}
