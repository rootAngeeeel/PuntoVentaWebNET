using PV.Modelos;

namespace Negocio.Service
{
    public interface IDetalleVentaService
    {
        Task<bool> Insert(DetalleVentum modelo);
        Task<bool> Update(DetalleVentum modelo);
        Task<bool> Delete(int id);
        Task<DetalleVentum> Select(int id);
        Task<IQueryable<DetalleVentum>> ObtenerDatos();
    }
}
