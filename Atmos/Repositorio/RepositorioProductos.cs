using Atmos.Modelos;
using Microsoft.EntityFrameworkCore;
namespace Atmos.Repositorio
{
    public class RepositorioProductos : IRepositorioProductos
    {
        private readonly AtmosDBContext _context;
        public RepositorioProductos(AtmosDBContext context)
        {
            _context = context;
        }
        public async Task<Producto> Add(Producto producto)
        {
            // Verificar si el producto ya existe basado en un campo único, como el nombre
            var productoExistente = await _context.Productos
                .FirstOrDefaultAsync(p => p.Nombre == producto.Nombre);

            if (productoExistente != null)
            {
                // Si el producto existe, incrementar el stock en 1
                productoExistente.Stock += producto.Stock;
                await _context.SaveChangesAsync();
                return productoExistente;
            }
            else
            {
                // Si el producto no existe, agregarlo a la base de datos
                await _context.Productos.AddAsync(producto);
                await _context.SaveChangesAsync();
                return producto;
            }
        }
        public async Task Delete(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Producto?> Get(int id)
        {
            return await _context.Productos
                .Include(p => p.Marcas) // Incluyendo la marca asociada
                .FirstOrDefaultAsync(p => p.ProductoId == id);
        }

        public async Task<List<Producto>> GetAll()
        {
            return await _context.Productos
                .Include(p => p.Marcas) // Incluyendo la marca asociada
                .ToListAsync();
        }
        public async Task Update(int id, Producto producto)
        {
            var productoactual = await _context.Productos.FindAsync(id);
            if (productoactual != null)
            {
                productoactual.Nombre = producto.Nombre;
                productoactual.Precio = producto.Precio;
                productoactual.Descripcion = producto.Descripcion;
                productoactual.Stock = producto.Stock;
                await _context.SaveChangesAsync();
            }
        }
    }
}