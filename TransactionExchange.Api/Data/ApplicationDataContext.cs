using Microsoft.EntityFrameworkCore;
using TransactionExchange.Api.Data.Entities;
using TransactionExchange.Api.Data.EntitiesConfigurations;

namespace TransactionExchange.Api.Data
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
        {
        }
        public DbSet<Transaction> Transactions => Set<Transaction>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new TransactionConfiguration());
        }
    }
}
