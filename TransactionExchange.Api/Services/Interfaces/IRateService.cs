using System.Threading.Tasks;
using TransactionExchange.Api.DTOs;

namespace TransactionExchange.Api.Services.Interfaces
{
    public interface IRateService
    {
        Task<RateDto> GetAsync();
    }
}
