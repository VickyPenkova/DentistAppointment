using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistAppointment.Controllers
{
    [Authorize]
    public class PatientController:Controller
    {
        [AllowAnonymous]
        public IActionResult forgottenPass()
        {
            return View("Views/pages/Patient/forgottenPass.cshtml");
        }
        [AllowAnonymous]
        public IActionResult loggedOut()
        {
            return View("Views/pages/Patient/loggedOut.cshtml");
        }
        public IActionResult patientAppointments()
        {
            return View("Views/pages/Patient/patientAppointments.cshtml");
        }
        public IActionResult patientBoking()
        {
            return View("Views/pages/Patient/patientBooking.cshtml");
        }
        public IActionResult patientCheckDocument()
        {
            return View("Views/pages/Patient/patientCheckDocument.cshtml");
        }
        public IActionResult patientDentistHomePage()
        {
            return View("Views/pages/Patient/patientDentistHomePage.cshtml");
        }
        public IActionResult patientEditInfo()
        {
            return View("Views/pages/Patient/patientEditInfo.cshtml");
        }
        public IActionResult patientFindDoctor()
        {
            return View("Views/pages/Patient/patientFindDoctor.cshtml");
        }
        public IActionResult patientHomePage()
        {
            return View("Views/pages/Patient/patientHomePage.cshtml");
        }
        public IActionResult patientMedicalManipulationsHistory()
        {
            return View("Views/pages/Patient/patientMedicalManipulationsHistory.cshtml");
        }
        public IActionResult patientOnFirstLogIn()
        {
            return View("Views/pages/Patient/patientOnFirstLogIn.cshtml");
        }
        public IActionResult patientRateAppointment()
        {
            return View("Views/pages/Patient/patientRateAppointment.cshtml");
        }
        [AllowAnonymous]
        public IActionResult registerPatient()
        {
            return View("Views/pages/Patient/registerPatient.cshtml");
        }
        [AllowAnonymous]
        public IActionResult index()
        {
            return View("Views/index.cshtml");
        }
    }
}
