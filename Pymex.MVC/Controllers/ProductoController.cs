using Pymex.MVC.AlmacenProxy;
using Pymex.MVC.CategoriaProxy;
using Pymex.MVC.Filters;
using Pymex.MVC.Models;
using Pymex.MVC.Models.CustomDataAnnotations;
using Pymex.MVC.Models.Mapper;
using Pymex.MVC.Models.Mapper.Contracts;
using Pymex.MVC.ProductoProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Pymex.MVC.Controllers
{
    [ValidateSession]
    public class ProductoController : Controller
    {

        private readonly ProductoMapper _modelMapper;

        private readonly IProductoService _productoService;
        private readonly ICategoriaService _categoriaService;
        private readonly IAlmacenService _almacenService;

        public ProductoController() 
        {
            _modelMapper = new ProductoMapper();
            _productoService = new ProductoServiceClient();
            _categoriaService = new CategoriaServiceClient();
            _almacenService = new AlmacenServiceClient();
        }

        // GET: Producto
        public ActionResult Index()
        {
            var response = _productoService.Listar();
            if (!response.EsCorrecto)
            {
                return RedirectToAction("Home", "Index");
            }

            var productos = response.Data.Select(p => _modelMapper.ToModel(p));

            return View(productos);
        }

        // GET: Producto/Details/5
        public ActionResult Details(string codigo)
        {
            var response = _productoService.ObtenerPorCodigo(codigo);
            if (!response.EsCorrecto)
            {
                return RedirectToAction("Index");
            }

            var producto = _modelMapper.ToDetailModel(response.Data);
            return View(producto);
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            ViewBag.Almacenes = _almacenService.Listar().Data;
            ViewBag.Categorias = _categoriaService.Listar().Data;
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude="Id")] Producto producto)
        {
            //ModelState.Keys.Remove("Id"); // Ignorando la validacion
            if (!ModelState.IsValid)
            {
                ViewBag.Almacenes = _almacenService.Listar().Data;
                ViewBag.Categorias = _categoriaService.Listar().Data;
                return View();
            }

            var response = _productoService.Crear(_modelMapper.ToDataContract(producto));
            if (!response.EsCorrecto)
            {
                ViewBag.Almacenes = _almacenService.Listar().Data;
                ViewBag.Categorias = _categoriaService.Listar().Data;
                ModelState.AddModelError("ErrorResponse", response.Mensaje);
                return View();
            }

            return RedirectToAction("Index");
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(string codigo)
        {
            var productoResponse = _productoService.ObtenerPorCodigo(codigo);
            var almacenesResponse = _almacenService.Listar();
            var categoriasResponse = _categoriaService.Listar();

            if (!(productoResponse.EsCorrecto && almacenesResponse.EsCorrecto && categoriasResponse.EsCorrecto))
            {
                // Tell the error messages
                return RedirectToAction("Home", "Index");
            }

            var producto = _modelMapper.ToModel(productoResponse.Data);
            ViewBag.Almacenes = almacenesResponse.Data;
            ViewBag.Categorias = categoriasResponse.Data;

            return View(producto);
        }

        // POST: Producto/Edit/5
        [HttpPost]
        public ActionResult Edit(Producto producto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Almacenes = _almacenService.Listar().Data;
                ViewBag.Categorias = _categoriaService.Listar().Data;
                return View();
            }

            var response = _productoService.Actualizar(_modelMapper.ToDataContract(producto));
            if (!response.EsCorrecto)
            {
                ViewBag.Almacenes = _almacenService.Listar().Data;
                ViewBag.Categorias = _categoriaService.Listar().Data;
                ModelState.AddModelError("ErrorResponse", response.Mensaje);
                return View();
            }

            return RedirectToAction("Index");

        }

        // POST: Producto/AlternarActivacion
        [HttpPost]
        public ActionResult AlternarActivacion(string codigo, bool activar = false)
        {
            var response = _productoService.ActivarPorCodigo(_modelMapper.ToActivateDataContract(codigo, activar));
            return RedirectToAction("Index");
        }
    }
}
