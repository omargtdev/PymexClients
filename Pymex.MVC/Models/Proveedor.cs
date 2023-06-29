using Pymex.MVC.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pymex.MVC.Models
{
    public class Proveedor
    {
        public int Id { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
    }
}