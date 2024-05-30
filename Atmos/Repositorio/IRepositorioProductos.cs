using Atmos.Modelos;
using Microsoft.AspNetCore.Identity;
namespace Atmos.Repositorio

{
    public interface IRepositorioProductos
    {
        Task<List<Producto>> GetAll();
        Task<Producto?> Get(int id);
        Task<Producto> Add(Producto producto);
        Task Update(int id, Producto producto);
        Task Delete(int id);
    }
}