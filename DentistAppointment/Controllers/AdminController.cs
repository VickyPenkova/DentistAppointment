using DentistAppointment.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistAppointment.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult index()
        {
            return View();
        }

        public IActionResult adminUsersList()
        {
            return View();
        }

        [HttpGet]
        public IActionResult registerDentist()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult registerDentist(User newDentist)
        {
            return View();
        }
    }
}
