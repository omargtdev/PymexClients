using Pymex.MVC.Filters;
using Pymex.MVC.Models.CustomDataAnnotations;
using Pymex.MVC.ProductoProxy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace Pymex.MVC.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El código es requrido.")]
        //[StringLength(8, MinimumLength = 6, ErrorMessage = "Debe tener un mínimo de 6 y un máximo de 8 caracteres.")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "La descripción es requerida.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Debe tener un mínimo de 2 y un máximo de 50 caracteres.")]
        public string Descripcion { get ; set; }

        [Required(ErrorMessage = "La categoria es requerida.")]
        public int CategoriaId { get ; set; }

        [DisplayName("Categoria")]
        public string CategoriaDescripcion { get ; set; }

        [Required(ErrorMessage = "El almacen es requerido.")]
        public int AlmacenId { get ; set; }

        [DisplayName("Almacen")]
        public string AlmacenDescripcion { get ; set; }

        public bool Activo { get; set; }

    }
}