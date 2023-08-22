using Microsoft.AspNetCore.Mvc;
using Negocio.Service;
using PV.Modelos;
using PV_Presentacion_Web.Models;
using PV_Presentacion_Web.Models.ViewModels;
using System.Diagnostics;

namespace PV_Presentacion_Web.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        public IActionResult ProductoVista()
        {
            return View();
        }

        /* Controlador de Producto */

        [HttpGet]
        public async Task<IActionResult> verProductos()
        {
            IQueryable<Producto> selectProducto = await _productoService.ObtenerDatos();

            List<ProductoViewModel> listaProductos = selectProducto
                .Select(c => new ProductoViewModel()
                {
                    id_producto = c.id_producto,
                    nombre = c.nombre,
                    proveedor = c.proveedor,
                    descripcion = c.descripcion
                }).ToList();

            return StatusCode(StatusCodes.Status200OK, listaProductos);
        }

        [HttpPost]
        public async Task<IActionResult> insertarProducto([FromBody] ProductoViewModel productoModel)
        {
            Producto row = new Producto()
            {
                nombre = productoModel.nombre,
                proveedor = productoModel.proveedor,
                descripcion = productoModel.descripcion
            };
            bool respuesta = false;
            try
            {
                respuesta = await _productoService.Insert(row);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        [HttpPut]
        public async Task<IActionResult> actualizarProducto([FromBody] ProductoViewModel productoModel)
        {
            Producto row = new Producto()
            {
                nombre = productoModel.nombre,
                proveedor = productoModel.proveedor,
                descripcion = productoModel.descripcion
            };

            bool respuesta = await _productoService.Update(row);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        }

        [HttpPost]
        public async Task<IActionResult> borrarProducto(int id)
        {
            bool respuesta = await _productoService.Delete(id);

            return StatusCode(StatusCodes.Status200OK, respuesta);
        }

        public IActionResult Privacy()
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
