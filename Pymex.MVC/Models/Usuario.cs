using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pymex.MVC.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public Perfil Perfil { get; set; }

        public string FullName
        {
            get => $"{Nombre} {Apellidos}";
        }

        public bool IsAdmin
        {
            get => Perfil == Perfil.Administrador;
        }

    }

    public enum Perfil
    {
        Empleado = 2,
        Administrador = 3
    }

}