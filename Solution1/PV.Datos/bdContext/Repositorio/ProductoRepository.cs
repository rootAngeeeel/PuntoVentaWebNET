using PV.Datos.bdContext;
using PV.Modelos;

namespace Datos.bdContext.Repositorio
{
    public class ProductoRepository : IGenericRepository<Producto>
    {
        private readonly PvefContext _vefContext;

        public ProductoRepository(PvefContext contexto)
        {
            _vefContext = contexto;
        }

        public async Task<bool> Delete(int id)
        {
            Producto producto = _vefContext.Productos.First(c => c.id_producto == id);
            _vefContext.Productos.Remove(producto);
            await _vefContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insert(Producto modelo)
        {
            _vefContext.Productos.Add(modelo);
            await _vefContext.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<Producto>> ObtenerDatos()
        {
            IQueryable<Producto> queryVenta = _vefContext.Productos;
            return queryVenta;
        }

        public async Task<Producto> Select(int id)
        {
            return await _vefContext.Productos.FindAsync(id);
        }

        public async Task<bool> Update(Producto modelo)
        {
            _vefContext.Productos.Update(modelo);
            await _vefContext.SaveChangesAsync();
            return true;
        }
    }
}
