using Pymex.MVC.Models.Mapper.Contracts;
using Pymex.MVC.ProductoProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pymex.MVC.Models.Mapper
{
    public class AlmacenMapper : IGenericMapper<AlmacenDC, Almacen>
    {
        public AlmacenDC ToDataContract(Almacen model)
        {
            return new AlmacenDC
            {
                Id = model.Id,
                Descripcion = model.Descripcion
            };
        }

        public Almacen ToModel(AlmacenDC dataContract)
        {
            return new Almacen
            {
                Id = dataContract.Id,
                Descripcion = dataContract.Descripcion,
                Direccion = dataContract.Direccion,
                Telefono = dataContract.Telefono,
                Aforo = dataContract.Aforo
            };
        }
    }
}