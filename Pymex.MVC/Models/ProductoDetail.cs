using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pymex.MVC.Models
{
    public class ProductoDetail : Producto
    {
        [DisplayName( "Ultimo Precio Compra")]
        [DisplayFormat(DataFormatString = "S/. {0:N2}")]
        public decimal UltimoPrecioCompra { get; set; }

        [DisplayName("Ultimo Precio Venta")]
        [DisplayFormat(DataFormatString = "S/. {0:N2}")]
        public decimal UltimoPrecioVenta { get; set; }

        public int Stock { get; set; }

        [DisplayName("Fecha Registro")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime FechaRegistro { get; set; }
    }
}