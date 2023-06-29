using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pymex.MVC.Models
{
    public class Almacen
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int Aforo { get; set; }
    }
}