using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace ticketsPrueba.Models
{
    public class ticketsContext : DbContext
    {
        public ticketsContext(DbContextOptions<ticketsContext> options) : base(options)
        {
        }

        public DbSet<usuarios> usuarios { get; set; }
        public DbSet<clientes> clientes { get; set; }
        public DbSet<tecnicos> tecnicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<usuarios>(entity =>
            {
                entity.HasKey(e => e.Id_usuario);
                // Puedes agregar más configuraciones aquí si es necesario
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}

