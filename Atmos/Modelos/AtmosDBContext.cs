using Microsoft.EntityFrameworkCore;
namespace Atmos.Modelos
{
    public class AtmosDBContext : DbContext
    {
        public AtmosDBContext(DbContextOptions<AtmosDBContext> options) : base(options)
        {
        }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Configuración de la precisión y la escala para la propiedad "Precio" en la entidad "Producto"
            modelBuilder.Entity<Producto>()
                .Property(p => p.Precio)
                .HasColumnType("decimal(18,2)"); //Especifica el tipo de columna en la base de datos SQL

        }
    }
}