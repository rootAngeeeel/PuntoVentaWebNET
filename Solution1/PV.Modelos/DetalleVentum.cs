using System;
using System.Collections.Generic;

namespace PV.Modelos
{

    public partial class DetalleVentum
    {
        public int IdDetalleVenta { get; set; }

        public int? IdVenta { get; set; }

        public double? PrecioXPieza { get; set; }

        public int? Cantidad { get; set; }

        public string? Descripcion { get; set; }

        public double? Importe { get; set; }
    }
}
