using Pymex.MVC.Cache;
using Pymex.MVC.Models.Mapper.Contracts;
using Pymex.MVC.ProductoProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pymex.MVC.Models.Mapper
{
    public class ProductoMapper : IGenericMapper<ProductoDC, Producto>, IModelDetailMapper<ProductoDC, ProductoDetail>
    {

        IGenericMapper<CategoriaDC, Categoria> _categoriaMapper;
        IGenericMapper<AlmacenDC, Almacen> _almacenMapper;

        public ProductoMapper()
        {
            _categoriaMapper = new CategoriaMapper();
            _almacenMapper = new AlmacenMapper();
        }

        public ProductoDC ToDataContract(Producto model)
        {
            return new ProductoDC
            {
                Id = model.Id,
                Codigo = model.Codigo,
                Descripcion = model.Descripcion,
                Categoria = new CategoriaDC { Id = model.CategoriaId },
                Almacen = new AlmacenDC { Id = model.AlmacenId },
                UsuarioAccion = UserLogged.Current.Login
            };
        }

        public ProductoDetail ToDetailModel(ProductoDC dataContract)
        {
            return new ProductoDetail
            {
                Id = dataContract.Id,
                Codigo = dataContract.Codigo,
                Descripcion = dataContract.Descripcion,
                CategoriaId = dataContract.Categoria.Id,
                CategoriaDescripcion = dataContract.Categoria.Descripcion,
                AlmacenId = dataContract.Almacen.Id,
                AlmacenDescripcion = dataContract.Almacen.Descripcion,
                Activo = dataContract.Activo,
                UltimoPrecioCompra = dataContract.UltimoPrecioCompra,
                UltimoPrecioVenta = dataContract.UltimoPrecioVenta,
                FechaRegistro = dataContract.HistorialSeguimiento.FechaRegistro
            };
        }

        public Producto ToModel(ProductoDC dataContract)
        {
            return new Producto
            {
                Id = dataContract.Id,
                Codigo = dataContract.Codigo,
                Descripcion = dataContract.Descripcion,
                CategoriaId = dataContract.Categoria.Id,
                CategoriaDescripcion = dataContract.Categoria.Descripcion,
                AlmacenId = dataContract.Almacen.Id,
                AlmacenDescripcion = dataContract.Almacen.Descripcion,
                Activo = dataContract.Activo,
            };
        }

        public ProductoDC ToActivateDataContract(string codigo, bool activar)
        {
            return new ProductoDC
            {
                Codigo = codigo,
                Activo = activar,
                UsuarioAccion = UserLogged.Current.Login
            };
        }
    }
}