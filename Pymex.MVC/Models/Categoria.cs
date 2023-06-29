using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pymex.MVC.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La descripción es requerida.")]
        public string Descripcion { get; set; }
    }
}