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
        : IModelDetailMapper<EntradaDC, EntradaDetail>,
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

        public EntradaDetail ToDetailModel(EntradaDC dataContract)
        {
            return new EntradaDetail
            {
                Id = dataContract.Id,
                Codigo = dataContract.Codigo,
                FechaRegistro = dataContract.FechaRegistro,
                IdProveedor = dataContract.Proveedor.Id,
                NombreProveedor = dataContract.Proveedor.NombreCompleto,
                UsuarioRegistro = dataContract.HistorialSeguimiento.UsuarioRegistro,
                Proveedor = new Proveedor
                {
                    Id = dataContract.Proveedor.Id,
                    TipoDocumento = (TipoDocumento)dataContract.Proveedor.TipoDocumento,
                    NumeroDocumento = dataContract.Proveedor.NumeroDocumento,
                    NombreCompleto = dataContract.Proveedor.NombreCompleto,
                    FechaRegistro = dataContract.Proveedor.HistorialSeguimiento.FechaRegistro
                },
                Productos = dataContract.DetalleProductos.Select(dp => new InventarioRegistroProducto
                {
                    Id = dp.Id,
                    Producto = new Producto
                    {
                        Id = dp.Producto.Id,
                        Codigo = dp.Producto.Codigo,
                        Descripcion = dp.Producto.Descripcion,
                        CategoriaId = dp.Producto.Categoria.Id,
                        CategoriaDescripcion = dp.Producto.Categoria.Descripcion,
                        AlmacenId = dp.Producto.Almacen.Id,
                        AlmacenDescripcion = dp.Producto.Almacen.Descripcion,
                        Activo = dp.Producto.Activo,
                    },
                    PrecioCompraUnidad = dp.PrecioCompraUnidad,
                    PrecioVentaUnidad = dp.PrecioVentaUnidad,
                    Cantidad = dp.Cantidad
                })
            };
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