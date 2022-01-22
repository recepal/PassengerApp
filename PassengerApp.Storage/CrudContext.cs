using Microsoft.EntityFrameworkCore;
using PassengerApp.Model;

namespace PassengerApp.Storage
{
    public class CrudContext : DbContext
    {
        public DbSet<Passenger> Passengers { get; set; }

        private readonly string _connectionString = "User ID=postgres; Password=deva; Host=localhost; Port=5432; Database=PassengerDb; Pooling=false; Timeout=300; CommandTimeout=180;";
        public CrudContext() { }

        public CrudContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public CrudContext(DbContextOptions<CrudContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}