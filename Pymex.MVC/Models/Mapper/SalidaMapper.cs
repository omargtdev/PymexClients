using Pymex.MVC.Cache;
using Pymex.MVC.InventarioProxy;
using Pymex.MVC.Models.Mapper.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pymex.MVC.Models.Mapper
{
    public class SalidaMapper 
        : IGenericMapper<SalidaDC, Salida>,
          ICreateMapper<SalidaDC, SalidaJsonCreate>
    {
        public SalidaDC ToCreateDataContract(SalidaJsonCreate model)
        {
            return new SalidaDC
            {
                FechaRegistro = model.RegisterDate,
                Cliente = new ClienteDC { Id = model.ClientId, TipoDocumento = InventarioProxy.TipoDocumento.DNI },
                UsuarioAccion = UserLogged.Current.Login,
                DetalleProductos = model.Products.Select(p => new SalidaDetalleDC
                {
                    Producto = new ProductoDC { Id = p.ProductId },
                    PrecioVentaUnidad = p.UnitSalePrice,
                    Cantidad = p.Quantity
                }).ToList()
            };
        }

        public SalidaDC ToDataContract(Salida model)
        {
            throw new NotImplementedException();
        }

        public Salida ToModel(SalidaDC dataContract)
        {
            return new Salida
            {
                Id = dataContract.Id,
                Codigo = dataContract.Codigo,
                FechaRegistro = dataContract.FechaRegistro,
                IdCliente = dataContract.Cliente.Id,
                NombreCliente = dataContract.Cliente.NombreCompleto,
                UsuarioRegistro = dataContract.HistorialSeguimiento.UsuarioRegistro
            };
        }
    }
}