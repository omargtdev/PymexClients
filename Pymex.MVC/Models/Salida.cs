using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Pymex.MVC.Models
{
    public class Salida
    {
        public int Id { get; set; }
        public string Codigo { get; set; }

        [DisplayName("Fecha Registro")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaRegistro { get; set; }

        [Required]
        [DisplayName("Id Cliente")]
        public int IdCliente { get; set; }
        
        [DisplayName("Nombre Cliente")]
        public string NombreCliente { get; set; }

        [DisplayName("Usuario Registro")]
        public string UsuarioRegistro { get; set; }
    }
}