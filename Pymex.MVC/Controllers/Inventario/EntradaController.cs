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
    [RoutePrefix("Inventario/Entrada")]
    [ValidateSession]
    public class EntradaController : Controller
    {

        private readonly IInventarioService _inventarioService = new InventarioServiceClient();
        private readonly EntradaMapper _modelMapper = new EntradaMapper();

        // GET: Entrada
        [Route]
        public ActionResult Index()
        {
            var response = _inventarioService.ListarEntradas();

            if (!response.EsCorrecto)
            {
                return RedirectToAction("Index", "Home");
            }

            var entradas = response.Data.Select(e => _modelMapper.ToModel(e));
            return View(entradas);
        }

        // GET: Entrada/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Entrada/Create
        [Route("Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Entrada/Create
        [Route("Create")]
        [HttpPost]
        public JsonResult RegistrarEntrada()
        {
            // Get json body
            var request = Request.InputStream;
            var json = new StreamReader(request).ReadToEnd();
            try
            {
                var entrada = JsonConvert.DeserializeObject<EntradaJsonCreate>(json);
                var response = _inventarioService.RegistrarEntrada(_modelMapper.ToCreateDataContract(entrada));
                if (!response.EsCorrecto)
                    throw new Exception();

            }
            catch
            {
                return Json(new { status = false, message = "Hubo un error al registrar la entrada." }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { status = true, message = "Se ingresó la entrada correctamente!" }, JsonRequestBehavior.AllowGet);
        }

        // GET: Entrada/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Entrada/Edit/5
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

        // GET: Entrada/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Entrada/Delete/5
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
