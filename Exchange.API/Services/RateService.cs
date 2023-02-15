using Exchange.API.DTOs;
using Exchange.API.Helpers.Enums;
using Exchange.API.Services.Interfaces;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Exchange.API.Services
{
    public class RateService : IRateService
    {
        private readonly HttpClient _client;
        public RateService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient(ExternalRestServices.RateService.ToString());
        }

        public async Task<RateDTO> GetAsync()
        {
            try
            {
                var response = await _client.GetAsync("/exchangerates_data/latest");
                return await response.Content.ReadFromJsonAsync<RateDTO>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
