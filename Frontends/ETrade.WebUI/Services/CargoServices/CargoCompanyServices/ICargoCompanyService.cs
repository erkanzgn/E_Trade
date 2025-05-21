using ETrade.DtoLayer.CargoDtos.CargoCompanyDtos;

namespace ETrade.WebUI.Services.CargoServices.CargoCompanyServices
{
    public interface ICargoCompanyService
    {
        Task<List<ResultCargoCompanyDto>> GetAllCargoCompanyAsync();
        Task CreateCargoCompanyAsync(CreateCargoCompanyDto cargoCompanyDto);
        Task UpdateCargoCompanyAsync(UpdateCargoCompanyDto cargoCompanyDto);
        Task DeleteCargoCompanyAsync(int id);
        Task<UpdateCargoCompanyDto> GetByIdCargoCompanyAsync(int id);
    }
}
