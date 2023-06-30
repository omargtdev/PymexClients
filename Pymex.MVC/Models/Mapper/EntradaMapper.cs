using Pymex.MVC.InventarioProxy;
using Pymex.MVC.Models.Mapper.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pymex.MVC.Models.Mapper
{
    public class EntradaMapper : IGenericMapper<EntradaDC, Entrada>
    {
        public EntradaDC ToDataContract(Entrada model)
        {
            throw new NotImplementedException();
        }

        public Entrada ToModel(EntradaDC dataContract)
        {
            return new Entrada
            {
                Id = dataContract.Id,
                Codigo = dataContract.Codigo,
                FechaRegistro = dataContract.FechaRegistro,
                IdProveedor = dataContract.Proveedor.Id,
                NombreProveedor = dataContract.Proveedor.NombreCompleto,
                UsuarioRegistro = dataContract.HistorialSeguimiento.UsuarioRegistro
            };
        }
    }
}