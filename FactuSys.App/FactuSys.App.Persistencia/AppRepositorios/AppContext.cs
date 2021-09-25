using  Microsoft.EntityFrameworkCore;
using FactuSys.App.Dominio;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FactuSys.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Persona> Personas{ get; set; }
        public DbSet<Cliente> Clientes{ get; set; }
        public DbSet<Empleado> Empleados{ get; set; }
        public DbSet<Establecimiento> Establecimientos{ get; set; }
        public DbSet<Registro> Registros{ get; set; }
        public DbSet<Factura> Facturas{ get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = FactuSysData ");
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
         modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

         modelBuilder.Entity<Registro>()
             .HasMany(r => r.Facturas).WithMany(f => f.Registros)
             .Map(t => t.MapLeftKey("RegistroID")
                 .MapRightKey("FacturaID")
                 .ToTable("RegistroFactura"));
      }
        
    }
}