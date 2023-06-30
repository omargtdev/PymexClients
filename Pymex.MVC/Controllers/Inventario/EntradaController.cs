using Pymex.MVC.InventarioProxy;
using Pymex.MVC.Models;
using Pymex.MVC.Models.Mapper;
using Pymex.MVC.Models.Mapper.Contracts;
using System.Linq;
using System.Web.Mvc;

namespace Pymex.MVC.Controllers.Inventario
{
    [RoutePrefix("Inventario/Entrada")]
    public class EntradaController : Controller
    {

        private readonly IInventarioService _inventarioService = new InventarioServiceClient();
        private readonly IGenericMapper<EntradaDC, Entrada> _modelMapper = new EntradaMapper();

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
        public ActionResult Create()
        {
            return View();
        }

        // POST: Entrada/Create
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
