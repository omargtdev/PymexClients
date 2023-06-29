using Pymex.MVC.Models.Mapper.Contracts;
using Pymex.MVC.ProductoProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pymex.MVC.Models.Mapper
{
    public class CategoriaMapper : IGenericMapper<CategoriaDC, Categoria>
    {
        public CategoriaDC ToDataContract(Categoria model)
        {
            throw new NotImplementedException();
        }

        public Categoria ToModel(CategoriaDC dataContract)
        {
            return new Categoria
            {
                Id = dataContract.Id,
                Descripcion = dataContract.Descripcion
            };
        }
    }
}