using Pymex.MVC.Models;
using Pymex.MVC.Models.Mapper;
using Pymex.MVC.Models.Mapper.Contracts;
using Pymex.MVC.ProveedorProxy;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Pymex.MVC.Controllers
{
    public class ProveedorController : Controller
    {
        
        private readonly IProveedorService _proveedorService = new ProveedorServiceClient();
        private readonly IGenericMapper<ProveedorDC, Proveedor> _modelMapper = new PersonaMapper();

        // GET: Proveedor
        public ActionResult Index()
        {
            var response = _proveedorService.Listar();

            if (!response.EsCorrecto)
            {
                return RedirectToAction("Home", "Index");
            }

            var proveedores = response.Data.Select(p => _modelMapper.ToModel(p));
            if (TempData["SuccessMessage"] != null) // Send message if exists
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();

            if (TempData["ErrorMessage"] != null) // Send message if exists
                ViewBag.ErrorMessage = TempData["ErrorMessage"].ToString();

            return View(proveedores);
        }

        // GET: Proveedor/Details/5
        public ActionResult Details(int id)
        {
            var response = _proveedorService.ObtenerPorId(id);
            if(!response.EsCorrecto)
            {
                TempData["ErrorMessage"] = "No se pudieron cargar los datos. Inténtelo de nuevo.";
                return RedirectToAction("Action");
            }

            var proveedor = _modelMapper.ToModel(response.Data);
            return View(proveedor);
        }

        // GET: Proveedor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proveedor/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude="Id")] Proveedor proveedor)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            
            var response = _proveedorService.Crear(_modelMapper.ToDataContract(proveedor));
            if(!response.EsCorrecto)
            {
                ViewBag.ErrorMessage = response.Mensaje;
                return View();
            }

            TempData["SuccessMessage"] = response.Mensaje;
            return RedirectToAction("Index");
        }

        // GET: Proveedor/Edit/5
        public ActionResult Edit(int id)
        {
            var response = _proveedorService.ObtenerPorId(id);
            if (!response.EsCorrecto)
            {
                TempData["ErrorMessage"] = "No se pudieron cargar los datos. Inténtelo de nuevo.";
                return RedirectToAction("Index");
            }

            return View(_modelMapper.ToModel(response.Data));
        }

        // POST: Proveedor/Edit/5
        [HttpPost]
        public ActionResult Edit(Proveedor proveedor)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var response = _proveedorService.Actualizar(_modelMapper.ToDataContract(proveedor));
            if (!response.EsCorrecto)
            {
                ViewBag.ErrorMessage = response.Mensaje;
                return View();
            }

            TempData["SuccessMessage"] = response.Mensaje;
            return RedirectToAction("Index");
        }

        // POST: Proveedor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var response = _proveedorService.Eliminar(id);

            if (response.EsCorrecto)
                TempData["SuccessMessage"] = response.Mensaje;
            else
                TempData["ErrorMessage"] = response.Mensaje;

            return RedirectToAction("Index");
        }

        public JsonResult GetProveedores(string expresion)
        {
            var response = _proveedorService.ListarPorExpresionYCantidad(expresion, 15);
            if (!response.EsCorrecto)
            {
                return Json(new { status = response.EsCorrecto, message = response.Mensaje }, JsonRequestBehavior.AllowGet);
            }

            var proveedores = response.Data.Select(p => _modelMapper.ToModel(p));
            return Json(proveedores, JsonRequestBehavior.AllowGet);
        }
    }
}
