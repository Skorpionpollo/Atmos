using Atmos.Modelos;

namespace Atmos.Repositorio;

public interface IRepositorioMarcas
{
    Task<List<Marca>> GetAll();
    Task<Marca?> Get(int id);
    Task<Marca> Add(Marca marca);
    Task Update(int id, Marca marca);
    Task Delete(int id);
}
