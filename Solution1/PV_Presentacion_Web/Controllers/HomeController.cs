using Microsoft.AspNetCore.Mvc;
using Negocio.Service;
using PV.Modelos;
using PV_Presentacion_Web.Models;
using PV_Presentacion_Web.Models.ViewModels;
using System.Diagnostics;

namespace PV_Presentacion_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDetalleVentaService _detalleVentaService;
        private readonly IVentaService _ventaService;
        private readonly IProductoService _productoService;

        public HomeController(IDetalleVentaService detalleVentaService, IVentaService ventaService, IProductoService productoService)
        {
            _detalleVentaService = detalleVentaService;
            _ventaService = ventaService;
            _productoService = productoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        /* Controlador DetalleVenta */
        [HttpGet]
        public async Task<IActionResult> verDetalleVenta()
        {
            IQueryable<DetalleVentum> selectDetalleVenta = await _detalleVentaService.ObtenerDatos();

            List<DetalleVentaViewModel> listaDetalleVenta = selectDetalleVenta
                .Select(c => new DetalleVentaViewModel()
                {
                    IdDetalleVenta = c.IdDetalleVenta,
                    IdVenta = c.IdVenta,
                    PrecioXPieza = c.PrecioXPieza,
                    Cantidad = c.Cantidad,
                    Descripcion = c.Descripcion,
                    Importe = c.Importe
                }).ToList();

            return StatusCode(StatusCodes.Status200OK, listaDetalleVenta);
        }

        [HttpPost]
        public async Task<IActionResult> insertDetalleVenta([FromBody] DetalleVentaViewModel detalleVenta_ViewModel)
        {
            DetalleVentum row = new DetalleVentum()
            {
                PrecioXPieza = detalleVenta_ViewModel.PrecioXPieza,
                Cantidad = detalleVenta_ViewModel.Cantidad,
                Descripcion = detalleVenta_ViewModel.Descripcion,
                Importe = detalleVenta_ViewModel.Importe
            };

            bool respuesta = await _detalleVentaService.Insert(row);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        [HttpPut]
        public async Task<IActionResult> actualizarDetalleVenta([FromBody] DetalleVentaViewModel detalleVenta_ViewModel)
        {
            DetalleVentum row = new DetalleVentum()
            {
                PrecioXPieza = detalleVenta_ViewModel.PrecioXPieza,
                Cantidad = detalleVenta_ViewModel.Cantidad,
                Descripcion = detalleVenta_ViewModel.Descripcion,
                Importe = detalleVenta_ViewModel.Importe
            };

            bool respuesta = await _detalleVentaService.Update(row);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        [HttpDelete]
        public async Task<IActionResult> borrarDetalleVenta(int id)
        {
            bool respuesta = await _detalleVentaService.Delete(id);

            return StatusCode(StatusCodes.Status200OK, respuesta);
        }

        /* Controlador Venta */
        [HttpGet]
        public async Task<IActionResult> verVenta()
        {
            IQueryable<Ventum> selectVenta = await _ventaService.ObtenerDatos();

            List<VentaViewModel> listaVenta = selectVenta
                .Select(c => new VentaViewModel()
                {
                    IdVenta = c.IdVenta,
                    Total = c.Total,
                    Fecha = c.Fecha
                }).ToList();

            return StatusCode(StatusCodes.Status200OK, listaVenta);
        }

        [HttpPost]
        public async Task<IActionResult> insertVenta([FromBody] VentaViewModel Venta_ViewModel)
         {
            Ventum row = new Ventum()
            {
                Total = Venta_ViewModel.Total,
                Fecha = Venta_ViewModel.Fecha
            };

            bool respuesta = await _ventaService.Insert(row);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        [HttpPut]
        public async Task<IActionResult> actualizarVenta([FromBody] VentaViewModel Venta_ViewModel)
        {
            Ventum row = new Ventum()
            {
                Total = Venta_ViewModel.Total,
                Fecha = Venta_ViewModel.Fecha
            };

            bool respuesta = await _ventaService.Update(row);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        }

        [HttpDelete]
        public async Task<IActionResult> borrarVenta(int id)
        {
            bool respuesta = await _ventaService.Delete(id);

            return StatusCode(StatusCodes.Status200OK, respuesta);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ProductoVista()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}