namespace PV_Presentacion_Web.Models.ViewModels
{
    public class DetalleVentaViewModel
    {

        public int IdDetalleVenta { get; set; }

        public int? IdVenta { get; set; }

        public double? PrecioXPieza { get; set; }

        public int? Cantidad { get; set; }

        public string? Descripcion { get; set; }

        public double? Importe { get; set; }

    }
}
