using Azure.Core;
using Datos.bdContext.Repositorio;
using PV.Modelos;

namespace Negocio.Service
{
    public class VentaServicie : IVentaService
    {
        private readonly IGenericRepository<Ventum> _ventaRepository;

        public VentaServicie(IGenericRepository<Ventum> ventaRepository)
        {
            _ventaRepository = ventaRepository;
        }

        public async Task<bool> Delete(int id)
        {
            return await _ventaRepository.Delete(id);
        }

        public async Task<bool> Insert(Ventum modelo)
        {
            return await _ventaRepository.Insert(modelo);
        }

        public async Task<IQueryable<Ventum>> ObtenerDatos()
        {
            return await _ventaRepository.ObtenerDatos();
        }

        public async Task<Ventum> Select(int id)
        {
            return await _ventaRepository.Select(id);
        }

        public async Task<bool> Update(Ventum modelo)
        {
            return await _ventaRepository.Update(modelo);
        }
    }
}
