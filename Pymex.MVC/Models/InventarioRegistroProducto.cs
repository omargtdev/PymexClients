using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pymex.MVC.Models
{
    public class InventarioRegistroProducto
    {

        public int Id { get; set; }

        public decimal PrecioCompraUnidad { get; set; }

        public decimal PrecioVentaUnidad { get; set; }

        public int Cantidad { get; set; }

        public Producto Producto { get; set; }
    }
}