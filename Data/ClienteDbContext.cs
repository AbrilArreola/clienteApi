using Microsoft.EntityFrameworkCore;
using ClienteApi.Models;

namespace ClienteApi.Data
{
    public class ClienteDbContext : DbContext
    {
        public ClienteDbContext(DbContextOptions<ClienteDbContext> options)
            : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
