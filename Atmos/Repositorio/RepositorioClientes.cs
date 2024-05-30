using Atmos.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Atmos.Repositorio
{
    public class RepositorioClientes : IRepositorioClientes
    {
        private readonly AtmosDBContext _context;

        public RepositorioClientes(AtmosDBContext context)
        {
            _context = context;
        }

        public async Task<Cliente> Add(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task Delete(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Cliente?> Get(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<List<Cliente>> GetAll()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task Update(int id, Cliente cliente)
        {
            var clienteActual = await _context.Clientes.FindAsync(id);
            if (clienteActual != null)
            {
                clienteActual.Nombre= cliente.Nombre;
                clienteActual.Correo= cliente.Correo;
                clienteActual.Telefono= cliente.Telefono;
                await _context.SaveChangesAsync();
            }
        }
    }
}
