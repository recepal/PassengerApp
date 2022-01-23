using Microsoft.EntityFrameworkCore;
using PassengerApp.Model;

namespace PassengerApp.Storage
{
    public class CrudContext : DbContext
    {
        public DbSet<Passenger> Passengers { get; set; }

        private readonly string _connectionString = "";
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