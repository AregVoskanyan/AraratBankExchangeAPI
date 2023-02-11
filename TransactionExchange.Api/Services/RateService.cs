using Microsoft.Extensions.Logging;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using TransactionExchange.Api.Services.Interfaces;
using TransactionExchange.Api.Enums;
using Azure.Core;
using System.Text.Json;
using System.Text;
using System.Net.Http.Json;
using TransactionExchange.Api.DTOs;

namespace TransactionExchange.Api.Services
{
    public class RateService : IRateService
    {
        private readonly HttpClient _client;
 
        public RateService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient(ExternalRestServices.RateService.ToString());
        }

        public async Task<RateDto> GetAsync()
        {
            try
            {
                var response = await _client.GetAsync("/exchangerates_data/latest");
                return await response.Content.ReadFromJsonAsync<RateDto>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
