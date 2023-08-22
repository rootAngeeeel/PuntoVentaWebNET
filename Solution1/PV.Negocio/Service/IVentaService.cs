
using PV.Modelos;

namespace Negocio.Service
{
    public interface IVentaService
    {
        Task<bool> Insert(Ventum modelo);
        Task<bool> Update(Ventum modelo);
        Task<bool> Delete(int id);
        Task<Ventum> Select(int id);
        Task<IQueryable<Ventum>> ObtenerDatos();
    }
}
