using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pymex.MVC.Models
{
    public class SalidaDetail : Salida
    {
        public Cliente Cliente { get; set; }
        public IEnumerable<InventarioRegistroProducto> Productos { get; set; }
    }
}