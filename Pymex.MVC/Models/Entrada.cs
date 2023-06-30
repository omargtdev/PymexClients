using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Pymex.MVC.Models
{
    public class Entrada
    {
        public int Id { get; set; }
        public string Codigo { get; set; }

        [DisplayName("Fecha Registro")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime FechaRegistro { get; set; }

        [Required]
        [DisplayName("Id Proveedor")]
        public int IdProveedor { get; set; }
        
        [DisplayName("Nombre Proveedor")]
        public string NombreProveedor { get; set; }

        [DisplayName("Usuario Registro")]
        public string UsuarioRegistro { get; set; }
        
    }
}