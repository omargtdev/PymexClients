using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pymex.MVC.Models
{
    public class EntradaDetail : Entrada
    {
        public Proveedor Proveedor { get; set; }
        public IEnumerable<InventarioRegistroProducto> Productos { get; set; }
    }
}