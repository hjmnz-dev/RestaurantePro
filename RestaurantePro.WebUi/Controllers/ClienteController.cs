using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using RestaurantePro.WebUi.Helpers;
using RestaurantePro.WebUi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace RestaurantePro.WebUi.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ApiHelper _apiHelper;

        public ClienteController()
        {
            _apiHelper = new ApiHelper("http://localhost:5049/api/Cliente/");
        }

        // GET: ClienteController
        public async Task<ActionResult> Index()
        {
            var result = await _apiHelper.GetApiResultAsync<ClienteListGetResult>("GetCliente");
            if (result == null)
            {
                ViewBag.ErrorMessage = "Error al obtener los datos del cliente.";
                return View();
            }

            return View(result.result ?? new List<ClienteGetModel>());
        }

        // GET: ClienteController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var result = await _apiHelper.GetApiResultAsync<ClienteGetResult>($"GetClientebyId?id={id}");
            if (result == null)
            {
                ViewBag.ErrorMessage = "Error al obtener los datos del Cliente.";
                return View();
            }

            return View(result.result);
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ClienteSaveModel clienteSave)
        {
            if (!ModelState.IsValid)
            {
                return View(clienteSave); 
            }

            var isSuccess = await _apiHelper.PostOrPutApiResultAsync("SaveCliente", clienteSave);
            if (!isSuccess)
            {
                ViewBag.ErrorMessage = "Error al guardar la cliente.";
                return View(clienteSave);
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ClienteUpdateModel clienteUpdate)
        {
            if (id != clienteUpdate.id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(clienteUpdate);
            }

            var isSuccess = await _apiHelper.PostOrPutApiResultAsync($"UpdateCliente?id={id}", clienteUpdate, isPut: true);
            if (!isSuccess)
            {
                ViewBag.ErrorMessage = "Error al actualizar el cliente.";
                return View(clienteUpdate);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
           
            return View();
        }
    }
}
