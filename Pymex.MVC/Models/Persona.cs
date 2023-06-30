using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Pymex.MVC.Models
{
    public class Persona
    {
        public int Id { get; set; }

        [DisplayName("Tipo Documento")]
        [Required(ErrorMessage = "El tipo de documento es requerido.")]
        [EnumDataType(typeof(TipoDocumento), ErrorMessage = "Debe colocar un tipo de documento valido.")]
        public TipoDocumento TipoDocumento { get; set; }

        public string TipoDocumentoDescripcion
        {
            get => Enum.GetName(typeof(TipoDocumento), TipoDocumento);
        }

        [DisplayName("Num. Documento")]
        [Required(ErrorMessage = "El numero de documeto es requerido.")]
        [StringLength(11, ErrorMessage = "El numero de documento de bebe ser un maximo de 11 digitos y un minimo de 8", MinimumLength = 8)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "El numero de documento debe ser solo numeros")]
        public string NumeroDocumento { get; set; }

        [DisplayName("Nombre Completo")]
        [Required(ErrorMessage = "El nombre completo es requerido.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Debe tener un mínimo de 2 y un máximo de 100 caracteres.")]
        public string NombreCompleto { get; set; }

        [DisplayName("Fecha Registro")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime FechaRegistro { get; set; }
    }

    // TODO: Valid correct numbers if it is a DNI or RUC
    //public class DocumentNumberLengthAttribute : ValidationAttribute
    //{
    //    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    //    {
    //        var persona = validationContext.ObjectInstance as Persona;
    //        string documentNumber = value.ToString().Trim();
    //        TipoDocumento.Tipos.ForEach(t =>
    //        {
    //            if (t.Id == persona.Id)

    //        });

    //        return base.IsValid(value, validationContext);
    //    }
    //}

    public enum TipoDocumento 
    {
        RUC = 1,
        DNI = 2
    }

}