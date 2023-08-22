using Datos.bdContext.Repositorio;
using PV.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Service
{
    public class DetalleVentaService : IDetalleVentaService
    {

        private readonly IGenericRepository<DetalleVentum> _ventaRepository;
        
        public DetalleVentaService(IGenericRepository<DetalleVentum> ventaRepository)
        {
            _ventaRepository = ventaRepository;
        }

        public async Task<bool> Delete(int id)
        {
            return await _ventaRepository.Delete(id);
        }

        public async Task<bool> Insert(DetalleVentum modelo)
        {
            return await _ventaRepository.Insert(modelo);
        }

        public async Task<IQueryable<DetalleVentum>> ObtenerDatos()
        {
            return await _ventaRepository.ObtenerDatos();
        }

        public async Task<DetalleVentum> Select(int id)
        {
            return await (_ventaRepository.Select(id));
        }

        public async Task<bool> Update(DetalleVentum modelo)
        {
            return await _ventaRepository.Update(modelo);
        }
    }
}
