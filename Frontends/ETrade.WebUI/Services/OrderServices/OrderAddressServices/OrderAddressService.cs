﻿using ETrade.DtoLayer.OrderDtos.OrderAddressDtos;
using Newtonsoft.Json;

namespace ETrade.WebUI.Services.OrderServices.OrderAddressServices
{
    public class OrderAddressService : IOrderAddressService
    {
        private readonly HttpClient _httpClient;

        public OrderAddressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateAddressAsync(CreateOrderAddressDto createOrderAddressDto)
        {
            await _httpClient.PostAsJsonAsync<CreateOrderAddressDto>("addresses", createOrderAddressDto);
        }

        public async Task DeleteAddressAsync(int id)
        {
            await _httpClient.DeleteAsync("addresses/RemoveAddress/" + id);
        }

        public async Task<List<UpdateOrderAddressDto>> GetAddressesByUserIdAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("addresses/getaddresslistbyuserid/" + id);
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<UpdateOrderAddressDto>>(jsondata);
            //var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdCategoryDto>();
            return value;
        }

        public async Task<List<ResultOrderAddressDto>> GetAllAddressAsync()
        {
            var responseMessage = await _httpClient.GetAsync("addresses");
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultOrderAddressDto>>(jsondata);
            //var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdCategoryDto>();
            return value;
        }

        public async Task<UpdateOrderAddressDto> GetByIdAddressAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("addresses/" + id);
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateOrderAddressDto>(jsondata);
            //var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdCategoryDto>();
            return value;
        }

        public async Task UpdateAddressAsync(UpdateOrderAddressDto updateOrderAddressDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateOrderAddressDto>("addresses", updateOrderAddressDto);
        }
        //private readonly HttpClient _httpClient;

        //public OrderAddressService(HttpClient httpClient)
        //{
        //    _httpClient = httpClient;
        //}
        //public async Task CreateOrderAddressAsync(CreateOrderAddressDto orderAddressDto)
        //{
        //    await _httpClient.PostAsJsonAsync<CreateOrderAddressDto>("addresses", orderAddressDto);
        //}

    }
}
