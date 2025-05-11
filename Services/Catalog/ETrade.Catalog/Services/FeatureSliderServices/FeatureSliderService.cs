using AutoMapper;
using ETrade.Catalog.Dtos.FeatureSliderDtos;
using ETrade.Catalog.Entities;
using ETrade.Catalog.Settings;
using MongoDB.Driver;

namespace ETrade.Catalog.Services.FeatureSliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly IMongoCollection<FeatureSlider> _FeatureSliderCollection;
        private readonly IMapper _mapper;

        public FeatureSliderService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _FeatureSliderCollection = database.GetCollection<FeatureSlider>(_databaseSettings.FeatureSliderCollectionName);
            _mapper = mapper;
        }

        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto featureSliderDto)
        {
            var value = _mapper.Map<FeatureSlider>(featureSliderDto);
            await _FeatureSliderCollection.InsertOneAsync(value);
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
            await _FeatureSliderCollection.DeleteOneAsync(x => x.FeatureSliderId == id);
        }

        public Task FeatureSliderChangeStatusToFalse(string id)
        {
            throw new NotImplementedException();
        }

        public Task FeatureSliderChangeStatusToTrue(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync()
        {
            var values = await _FeatureSliderCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultFeatureSliderDto>>(values);
        }

        public async Task<GetByIdFeatureSliderDto> GetByIdFeatureSliderAsync(string id)
        {
            var values = await _FeatureSliderCollection.Find(x => x.FeatureSliderId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdFeatureSliderDto>(values);
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto featureSliderDto)
        {
            var values = _mapper.Map<FeatureSlider>(featureSliderDto);
            await _FeatureSliderCollection.FindOneAndReplaceAsync(x => x.FeatureSliderId == featureSliderDto.FeatureSliderId, values);
        }
    }
}
