using PV.Datos.bdContext;
using PV.Modelos;

namespace Datos.bdContext.Repositorio
{
    public class DetalleVentaRepository : IGenericRepository<DetalleVentum>
    {
        private readonly PvefContext _vefContext;

        public DetalleVentaRepository(PvefContext contexto)
        {
            _vefContext = contexto;
        }

        public async Task<bool> Delete(int id)
        {
            DetalleVentum Detalle_venta = _vefContext.DetalleVenta.First(c => c.IdDetalleVenta == id);
            _vefContext.DetalleVenta.Remove(Detalle_venta);
            await _vefContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insert(DetalleVentum modelo)
        {
            _vefContext.DetalleVenta.Add(modelo);
            await _vefContext.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<DetalleVentum>> ObtenerDatos()
        {
            IQueryable<DetalleVentum> queryVenta = _vefContext.DetalleVenta;
            return queryVenta;
        }

        public async Task<DetalleVentum> Select(int id)
        {
            return await _vefContext.DetalleVenta.FindAsync(id);
        }

        public async Task<bool> Update(DetalleVentum modelo)
        {
            _vefContext.DetalleVenta.Update(modelo);
            await _vefContext.SaveChangesAsync();
            return true;
        }
    }
}
