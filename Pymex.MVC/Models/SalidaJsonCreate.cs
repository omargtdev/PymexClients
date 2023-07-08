using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pymex.MVC.Models
{
    public class SalidaJsonCreate
    {
        public DateTime RegisterDate { get; set; }
        public int ClientId { get; set; }
        public IEnumerable<EntradaProducto> Products { get; set; }
        public struct EntradaProducto
        {
            public int ProductId { get; set; }
            public decimal UnitSalePrice { get; set; }
            public int Quantity { get; set; }

        }
    }
}