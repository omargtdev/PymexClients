using Pymex.MVC.Models.Mapper.Contracts;
using Pymex.MVC.UsuarioProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pymex.MVC.Models.Mapper
{
    public class UsuarioMapper : IGenericMapper<UsuarioDC, Usuario>
    {
        public UsuarioDC ToDataContract(Usuario model)
        {
            throw new NotImplementedException();
        }

        public Usuario ToModel(UsuarioDC dataContract)
        {
            return new Usuario
            {
                Id = dataContract.Id,
                Login = dataContract.Login,
                Nombre = dataContract.Nombre,
                Apellidos = dataContract.Apellidos,
                Perfil = (Perfil)dataContract.Perfil
            };
        }
    }
}