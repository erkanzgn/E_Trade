﻿using ETrade.Catalog.Dtos.ProductImageDtos;

namespace ETrade.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllProductImageAsync();
        Task CreateProductImageAsync(CreateProductImageDto ProductImageDto);
        Task UpdateProductImageAsync(UpdateProductImageDto ProductImageDto);
        Task DeleteProductImageAsync(string id);
        Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id);
        Task<GetByIdProductImageDto>GetByProductIdProductImageAsync(string id);
    }
}
