using System.ComponentModel.DataAnnotations;

namespace Pymex.MVC.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La descripción es requerida.")]
        public string Descripcion { get; set; }
    }
}