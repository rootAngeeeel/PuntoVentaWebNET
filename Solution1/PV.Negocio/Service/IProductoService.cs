using PV.Modelos;

namespace Negocio.Service
{
    public interface IProductoService
    {
        Task<bool> Insert(Producto modelo);
        Task<bool> Update(Producto modelo);
        Task<bool> Delete(int id);
        Task<Producto> Select(int id);
        Task<IQueryable<Producto>> ObtenerDatos();
    }
}
