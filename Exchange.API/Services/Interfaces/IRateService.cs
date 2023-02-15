using Exchange.API.DTOs;
using System.Threading.Tasks;

namespace Exchange.API.Services.Interfaces
{
    public interface IRateService
    {
        Task<RateDTO> GetAsync();
    }
}
