using Pymex.MVC.ClienteProxy;
using Pymex.MVC.Filters;
using Pymex.MVC.Models;
using Pymex.MVC.Models.Mapper;
using Pymex.MVC.Models.Mapper.Contracts;
using System.Linq;
using System.Web.Mvc;

namespace Pymex.MVC.Controllers
{
    [ValidateSession]
    public class ClienteController : Controller
    {

        private readonly IClienteService _clienteService = new ClienteServiceClient();
        private readonly IGenericMapper<ClienteDC, Cliente> _modelMapper = new PersonaMapper();

        public ActionResult Index()
        {
            var response = _clienteService.Listar();

            if (!response.EsCorrecto)
            {
                return RedirectToAction("Home", "Index");
            }

            var clientes = response.Data.Select(c => _modelMapper.ToModel(c));
            if (TempData["SuccessMessage"] != null) // Send message if exists
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();

            if (TempData["ErrorMessage"] != null) // Send message if exists
                ViewBag.ErrorMessage = TempData["ErrorMessage"].ToString();


            return View(clientes);
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            var response = _clienteService.ObtenerPorId(id);
            if(!response.EsCorrecto)
            {
                TempData["ErrorMessage"] = "No se pudieron cargar los datos. Inténtelo de nuevo.";
                return RedirectToAction("Action");
            }

            var cliente = _modelMapper.ToModel(response.Data);
            return View(cliente);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude="Id")] Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            
            var response = _clienteService.Crear(_modelMapper.ToDataContract(cliente));
            if(!response.EsCorrecto)
            {
                ViewBag.ErrorMessage = response.Mensaje;
                return View();
            }

            TempData["SuccessMessage"] = response.Mensaje;
            return RedirectToAction("Index");
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            var response = _clienteService.ObtenerPorId(id);
            if (!response.EsCorrecto)
            {
                TempData["ErrorMessage"] = "No se pudieron cargar los datos. Inténtelo de nuevo.";
                return RedirectToAction("Index");
            }

            return View(_modelMapper.ToModel(response.Data));
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var response = _clienteService.Actualizar(_modelMapper.ToDataContract(cliente));
            if (!response.EsCorrecto)
            {
                ViewBag.ErrorMessage = response.Mensaje;
                return View();
            }

            TempData["SuccessMessage"] = "Se editó el cliente correctamente";
            return RedirectToAction("Index");
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var response = _clienteService.Eliminar(id);

            if (response.EsCorrecto)
                TempData["SuccessMessage"] = response.Mensaje;
            else
                TempData["ErrorMessage"] = response.Mensaje;

            return RedirectToAction("Index");
        }
    }
}
