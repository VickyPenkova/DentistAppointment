using DentistAppointment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DentistAppointment.Controllers
{
    //[Authorize]
    public class PatientController:Controller
    {
        // Default page fot patient log in
        [AllowAnonymous]
        public IActionResult index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult forgottenPass()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult loggedOut()
        {
            return View();
        }

        public IActionResult patientHomePage()
        {
            return View();
        }

        public IActionResult patientAppointments()
        {
            return View();
        }
        public IActionResult patientBooking()
        {
            return View();
        }
        public IActionResult patientCheckDocument()
        {
            return View();
        }
        public IActionResult patientDentistHomePage()
        {
            return View();
        }
        public IActionResult patientEditInfo()
        {
            return View();
        }
        public IActionResult patientFindDoctor()
        {
            return View();
        }

        public IActionResult patientMedicalManipulationsHistory()
        {
            return View();
        }
        public IActionResult patientOnFirstLogIn()
        {
            return View();
        }
        public IActionResult patientRateAppointment()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult registerPatient()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
