using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Xml.Linq;
using TransactionExchange.Api.Data.Entities;

namespace TransactionExchange.Api.Data.EntitiesConfigurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
             builder.Property(e => e.Currency).HasMaxLength(3);
        }
    }
}
