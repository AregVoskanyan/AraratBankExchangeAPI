using AutoMapper;
using TransactionExchange.Api.Data.Entities;
using TransactionExchange.Api.DTOs;

namespace TransactionExchange.Api.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<TransactionDto, Transaction>();
        }
    }
}
