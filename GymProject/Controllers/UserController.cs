using GymProject.Areas.Identity.Data;
using GymProject.CommandQueries.Commands;
using GymProject.CommandQueries.Queries;
using GymProject.Controllers.Core;
using GymProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GymProject.Controllers
{
    public class UserController : BaseController
    {

        public async Task<ActionResult> CreateUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUser(Client model)
        {
          Mediator.Send(new CreateUserCommand.Command { client = model });
          return RedirectToAction("Index", "Home");
        }

        public async Task<ActionResult> GetAllClientsList()
        {
            var response = (await Mediator.Send(new GetAllClients.Query { })).Value;
            return View(response);
        }

        public async Task<ActionResult> Edit(int id)
        {
            var response = (await Mediator.Send(new GetSingleClient.Query { Id = id })).Value;
            return View(response);
        }

        public async Task<ActionResult> Details(int id)
        {
            var response = (await Mediator.Send(new GetSingleClient.Query { Id = id })).Value;
            return View(response);
        }

        public async Task<ActionResult> AddCarnet()
        {
            var clients = (await Mediator.Send(new GetAllClients.Query { })).Value;
            ViewBag.Clients = CreateSelectList(clients);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCarnet(Carnet model)
        {
            Mediator.Send(new CreateCarnet.Command { carnet = model });
            return RedirectToAction("GetAllClientsList", "User");
        }

        public ActionResult ValidateCarnet()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ValidateCarnet(Carnet model)
        {
            var carnet  = (await Mediator.Send(new ValidateCarnetQuery.Query { carnet = model })).Value;

            return RedirectToAction("Details", new { id = carnet.Id });
        }


        private SelectList CreateSelectList(IEnumerable<Client> clients)
        {
            return new SelectList(clients.Select(d => new SelectListItem
            {
                Text = $"{d.Name} ",
                Value = d.Id.ToString()
            }), "Value", "Text");
        }

    }
}
