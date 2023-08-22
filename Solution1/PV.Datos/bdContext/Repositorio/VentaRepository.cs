using PV.Datos.bdContext;
using PV.Modelos;

namespace Datos.bdContext.Repositorio
{
    public class VentaRepository : IGenericRepository<Ventum>
    {
        private readonly PvefContext _vefContext;

        public VentaRepository(PvefContext context)
        {
            _vefContext = context;
        }

        public async Task<bool> Delete(int id)
        {
            Ventum venta = _vefContext.Venta.First(c => c.IdVenta == id);
            _vefContext.Venta.Remove(venta);
            await _vefContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insert(Ventum modelo)
        {
            _vefContext.Venta.Add(modelo);
            await _vefContext.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<Ventum>> ObtenerDatos()
        {
            IQueryable<Ventum> queryVenta = _vefContext.Venta;
            return queryVenta;
        }

        public async Task<Ventum> Select(int id)
        {
            return await _vefContext.Venta.FindAsync(id);
        }

        public async Task<bool> Update(Ventum modelo)
        {
            _vefContext.Venta.Update(modelo);
            await _vefContext.SaveChangesAsync();
            return true;
        }
    }
}
