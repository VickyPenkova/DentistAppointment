using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistAppointment.Controllers
{
    public class DentistController : Controller
    {
        public IActionResult index()
        {
            return View();
        }

        public IActionResult dentistAppointments()
        {
            return View();
        }

        public IActionResult dentistCheckDocument()
        {
            return View();
        }

        public IActionResult dentistDocumentManipulation()
        {
            return View();
        }

        public IActionResult dentistEditInfo()
        {
            return View();
        }

        public IActionResult dentistFindAPatient()
        {
            return View();
        }

        public IActionResult dentistForgottenPass()
        {
            return View();
        }

        public IActionResult dentistHomePage()
        {
            return View();
        }

        public IActionResult dentistMedicalManipulations()
        {
            return View();
        }

        public IActionResult dentistOnFirstLogIn()
        {
            return View();
        }

        public IActionResult dentistPatientHomePage()
        {
            return View();
        }

        public IActionResult loggedOut()
        {
            return View();
        }
    }
}
