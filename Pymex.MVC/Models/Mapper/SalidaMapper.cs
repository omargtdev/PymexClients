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
        : IModelDetailMapper<SalidaDC, SalidaDetail>,
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

        public SalidaDetail ToDetailModel(SalidaDC dataContract)
        {
            return new SalidaDetail
            {
                Id = dataContract.Id,
                Codigo = dataContract.Codigo,
                FechaRegistro = dataContract.FechaRegistro,
                IdCliente = dataContract.Cliente.Id,
                NombreCliente = dataContract.Cliente.NombreCompleto,
                UsuarioRegistro = dataContract.HistorialSeguimiento.UsuarioRegistro,
                Cliente = new Cliente
                {
                    Id = dataContract.Cliente.Id,
                    TipoDocumento = (TipoDocumento)dataContract.Cliente.TipoDocumento,
                    NumeroDocumento = dataContract.Cliente.NumeroDocumento,
                    NombreCompleto = dataContract.Cliente.NombreCompleto,
                    FechaRegistro = dataContract.Cliente.HistorialSeguimiento.FechaRegistro
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
                    PrecioVentaUnidad = dp.PrecioVentaUnidad,
                    Cantidad = dp.Cantidad
                })
            };
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