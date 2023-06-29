using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pymex.MVC.ValueObjects
{
    public struct TipoDocumento
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }
}