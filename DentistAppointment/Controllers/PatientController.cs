using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistAppointment.Controllers
{
    //[Authorize]
    public class PatientController:Controller
    {
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
            //return View("/Views/Patient/PatientBoking.cshtml");
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
        [AllowAnonymous]
        public IActionResult index()
        {
            return View();
        }
    }
}
