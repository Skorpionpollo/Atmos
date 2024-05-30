using Atmos.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Atmos.Repositorio
{
    public class RepositorioMarcas : IRepositorioMarcas
    {
        private readonly AtmosDBContext _context;

        public RepositorioMarcas(AtmosDBContext context)
        {
            _context = context;
        }

        public async Task<List<Marca>> GetAll()
        {
            return await _context.Marcas.ToListAsync();
        }

        public async Task<Marca?> Get(int id)
        {
            return await _context.Marcas.FindAsync(id);
        }

        public async Task<Marca> Add(Marca marca)
        {
            await _context.Marcas.AddAsync(marca);
            await _context.SaveChangesAsync();
            return marca;
        }

        public async Task Update(int id, Marca marca)
        {
            var marcaActual = await _context.Marcas.FindAsync(id);
            if (marcaActual != null)
            {
                _context.Entry(marcaActual).CurrentValues.SetValues(marca);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var marca = await _context.Marcas.FindAsync(id);
            if (marca != null)
            {
                _context.Marcas.Remove(marca);
                await _context.SaveChangesAsync();
            }
        }
    }
}
