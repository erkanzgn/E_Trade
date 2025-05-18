using ETrade.DtoLayer.CatalogDtos.ContactDtos;

namespace ETrade.WebUI.Services.CatalogServices.ContactServices
{
    public interface IContactService
    {
        Task<List<ResultContactDto>> GetAllContactAsync();
        Task CreateContactAsync(CreateContactDto contactDto);
        Task UpdateContactAsync(UpdateContactDto contactDto);
        Task DeleteContactAsync(string id);
        Task<GetByIdContactDto> GetByIdContactAsync(string id);
    }
}
