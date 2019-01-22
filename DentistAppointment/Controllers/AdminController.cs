using DentistAppointment.Data.Models;
using DentistAppointment.Models.AdminViewModels;
using DentistAppointment.Services.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistAppointment.Controllers
{
    public class AdminController : Controller
    {
        private readonly IHttpContextAccessor httpaccessor;
        private readonly IUsersService usersService;
        private readonly IDentistsService dentistsService;

        public AdminController(
            IHttpContextAccessor httpaccessor,
            IUsersService usersService,
            IDentistsService dentistsService)
        {
            this.httpaccessor = httpaccessor;
            this.usersService = usersService;
            this.dentistsService = dentistsService;
        }

        public IActionResult index()
        {
            return View();
        }

        public IActionResult adminUsersList()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult registerDentist(AddDentistViewModel model, string returnUrl = null)
        {
            this.ViewData["ReturnUrl"] = returnUrl;
            var resultModel = new AddDentistViewModel();
            if (this.ModelState.IsValid)
            {
                this.dentistsService.Save(model);
                ViewData["Message"] = "SUCCESS!";
            }

            return View();
        }

        [HttpGet]
        public IActionResult registerDentist(string returnUrl = null)
        {
            this.ViewData["ReturnUrl"] = returnUrl;
            return View(new AddDentistViewModel());
        }
    }
}
