﻿using ETrade.DtoLayer.CommentDtos;
using ETrade.DtoLayer.OrderDtos.OrderOrderingDto;
using Newtonsoft.Json;

namespace ETrade.WebUI.Services.OrderServices.OrderOrderingServices
{
    public class OrderOrderingService : IOrderOrderingService
    {
        private readonly HttpClient _httpClient;

        public OrderOrderingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId(string id)
        {
          

            var responseMessage = await _httpClient.GetAsync($"Orderings/GetOrderingByUserId/{id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultOrderingByUserIdDto>>(jsonData);
            return values;


        }

    }
}
