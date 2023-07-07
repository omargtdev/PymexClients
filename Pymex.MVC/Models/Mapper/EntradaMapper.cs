using Pymex.MVC.Cache;
using Pymex.MVC.InventarioProxy;
using Pymex.MVC.Models.Mapper.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pymex.MVC.Models.Mapper
{
    public class EntradaMapper 
        : IGenericMapper<EntradaDC, Entrada>,
          ICreateMapper<EntradaDC, EntradaJsonCreate>
    {
        public EntradaDC ToCreateDataContract(EntradaJsonCreate model)
        {
            return new EntradaDC
            {
                FechaRegistro = model.RegisterDate,
                Proveedor = new ProveedorDC { Id = model.ProviderId, TipoDocumento = InventarioProxy.TipoDocumento.DNI },
                UsuarioAccion = UserLogged.Current.Login,
                DetalleProductos = model.Products.Select(p => new EntradaDetalleDC
                {
                    Producto = new ProductoDC { Id = p.ProductId },
                    PrecioCompraUnidad = p.UnitPurchasePrice,
                    PrecioVentaUnidad = p.UnitSalePrice,
                    Cantidad = p.Quantity
                }).ToList()
            };
        }

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