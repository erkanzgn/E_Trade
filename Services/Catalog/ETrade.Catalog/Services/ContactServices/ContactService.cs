using AutoMapper;
using ETrade.Catalog.Dtos.ContactDtos;
using ETrade.Catalog.Entities;
using ETrade.Catalog.Settings;
using MongoDB.Driver;

namespace ETrade.Catalog.Services.ContactServices
{
    public class ContactService:IContactService
    {
        private readonly IMongoCollection<Contact> _contactCollection;
        private readonly IMapper _mapper;

        public ContactService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _contactCollection = database.GetCollection<Contact>(_databaseSettings.ContactCollectionName);
            _mapper = mapper;
        }

        public async Task CreateContactAsync(CreateContactDto contactDto)
        {
            var value = _mapper.Map<Contact>(contactDto);
            await _contactCollection.InsertOneAsync(value);
        }

        public async Task DeleteContactAsync(string id)
        {
            await _contactCollection.DeleteOneAsync(x => x.ContactId == id);
        }

        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            var values = await _contactCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultContactDto>>(values);
        }

        public async Task<GetByIdContactDto> GetByIdContactAsync(string id)
        {
            var values = await _contactCollection.Find(x => x.ContactId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdContactDto>(values);
        }

        public async Task UpdateContactAsync(UpdateContactDto contactDto)
        {
            var values = _mapper.Map<Contact>(contactDto);
            await _contactCollection.FindOneAndReplaceAsync(x => x.ContactId == contactDto.ContactId, values);
        }
    }
}
