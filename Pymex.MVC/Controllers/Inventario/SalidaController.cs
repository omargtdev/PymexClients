using Pymex.MVC.Filters;
using Pymex.MVC.InventarioProxy;
using Pymex.MVC.Models;
using Pymex.MVC.Models.Mapper;
using Pymex.MVC.Models.Mapper.Contracts;
using System.Linq;
using System.Web.Mvc;

namespace Pymex.MVC.Controllers.Inventario
{
    [RoutePrefix("Inventario/Salida")]
    [ValidateSession]
    public class SalidaController : Controller
    {

        private readonly IInventarioService _inventarioService = new InventarioServiceClient();
        private readonly IGenericMapper<SalidaDC, Salida> _modelMapper = new SalidaMapper();

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
        public ActionResult Create()
        {
            return View();
        }

        // POST: Salida/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
