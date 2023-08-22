using Datos.bdContext.Repositorio;
using PV.Modelos;

namespace Negocio.Service
{
    public class ProductoService : IProductoService
    {
        private readonly IGenericRepository<Producto> _productoRepository;

        public ProductoService(IGenericRepository<Producto> productoRepo)
        {
            _productoRepository = productoRepo;
        }

        public async Task<bool> Delete(int id)
        {
            return await _productoRepository.Delete(id);
        }

        public async Task<bool> Insert(Producto modelo)
        {
            return await _productoRepository.Insert(modelo);
        }

        public async Task<IQueryable<Producto>> ObtenerDatos()
        {
            return await _productoRepository.ObtenerDatos();
        }

        public async Task<Producto> Select(int id)
        {
            return await _productoRepository.Select(id);
        }

        public async Task<bool> Update(Producto modelo)
        {
            return await _productoRepository.Update(modelo);
        }
    }
}
