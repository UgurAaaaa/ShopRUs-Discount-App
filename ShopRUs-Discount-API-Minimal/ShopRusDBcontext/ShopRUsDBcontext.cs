using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShopRUs_Discount_API_Minimal.Entities.DtoEntites;

namespace ShopRUs_Discount_API_Minimal.ShopRusDBcontext
{
    public class ShopRUsDBcontext : DbContext
    {
        private readonly string _connString;

        public ShopRUsDBcontext()
        {
            _connString = GetConnString();
        }

        private string GetConnString()
        {
            var configurationBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = configurationBuilder.Build();
            return configuration.GetConnectionString("ShopRUsDB");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: _connString);
        }

        public DbSet<CustomersDTO> Customers { get; set; }
        public DbSet<CustomerTypeDTO> CustomerTypes { get; set; } 
        public DbSet<InvoiceDTO> Invoice { get; set; }
    }
}