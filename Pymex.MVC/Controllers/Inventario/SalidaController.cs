using Newtonsoft.Json;
using Pymex.MVC.Filters;
using Pymex.MVC.InventarioProxy;
using Pymex.MVC.Models;
using Pymex.MVC.Models.Mapper;
using Pymex.MVC.Models.Mapper.Contracts;
using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace Pymex.MVC.Controllers.Inventario
{
    [RoutePrefix("Inventario/Salida")]
    [ValidateSession]
    public class SalidaController : Controller
    {

        private readonly IInventarioService _inventarioService = new InventarioServiceClient();
        private readonly SalidaMapper _modelMapper = new SalidaMapper();

        // GET: Salida
        [Route]
        public ActionResult Index()
        {
            var response = _inventarioService.ListarSalidas();

            if (!response.EsCorrecto)
            {
                return RedirectToAction("Index", "Home");
            }

            var salidas = response.Data.Select(s => _modelMapper.ToModel(s));
            return View(salidas);
        }

        // GET: Salida/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Salida/Create
        [Route("Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Salida/Create
        [Route("Create")]
        [HttpPost]
        public JsonResult RegistrarSalida()
        {
            // Get json body
            var request = Request.InputStream;
            var json = new StreamReader(request).ReadToEnd();
            try
            {
                var salida = JsonConvert.DeserializeObject<SalidaJsonCreate>(json);
                var response = _inventarioService.RegistrarSalida(_modelMapper.ToCreateDataContract(salida));
                if (!response.EsCorrecto)
                    throw new Exception();
            }
            catch
            {
                return Json(new { status = false, message = "Hubo un error al registrar la salida." }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { status = true, message = "Se ingresó la salida correctamente!" }, JsonRequestBehavior.AllowGet);
        }

        // GET: Salida/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Salida/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Salida/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Salida/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
