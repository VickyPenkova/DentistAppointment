using DentistAppointment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using DentistAppointment.Services.Abstraction;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using DentistAppointment.Data.Models;
using DentistAppointment.Models.PatientViewModel;
using DentistAppointment.DTOs;

namespace DentistAppointment.Controllers
{
   [Authorize]
    public class PatientController:Controller
    {
        private readonly IHttpContextAccessor httpaccessor;
        private readonly IUsersService usersService;
        private readonly IDentistsService dentistsService;
        private readonly IReservationsService reservationsService;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public PatientController(
            IUsersService usersService,
            IDentistsService dentistsService,
            IHttpContextAccessor httpContextAccessor,
            IReservationsService reservationsService,
            IMapper mapper,
            UserManager<User> userManager)
        {
            this.usersService = usersService;
            this.dentistsService = dentistsService;
            this.reservationsService = reservationsService;
            this.httpaccessor = httpContextAccessor;
            this.mapper = mapper;
            this.userManager = userManager;
        }

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
        private string GetCurrentUserId() => this.userManager.GetUserId(HttpContext.User);
        public IActionResult patientHomePage()
        {
             string userId = GetCurrentUserId();
            var user = this.usersService.GetAllUsers().FirstOrDefault(u => u.Id == userId);
            //var comments = commentsService.GetAllCommentsOfPatient(user.Id).ToList();

            var viewModel = new PatientHomePageViewModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                 Rating = user.Rating,
                 Email = user.Email,
                // Comments=comments,
                 EGN = user.EGN

             };

             return View(viewModel);
        }

        public IActionResult patientAppointments()
        {
            return View();
        }
        public IActionResult patientBooking()
        {
            // HARDCODE
            int DENTIST_ID = 1;

            var model = new PatientBookingModel()
            {
                WorkHours = reservationsService.GetDentistWorkHoursForDay(1, new DateTime(2019, 1, 8))
            };
            return View(model);
        }
        public IActionResult patientCheckDocument()
        {
            return View();
        }
        public IActionResult patientDentistHomePage()
        {
            string userId = GetCurrentUserId();
            var dentist = this.dentistsService
                .GetAllDentists().FirstOrDefault(user => user.User.Id == userId);

            var viewModel = new PatientDentistHomePageViewModel()
            {
                User = this.usersService.GetAllUsers().FirstOrDefault(x => x.Dentist == dentist),
                Address = dentist.Address,
                Type = dentist.Type,
                Rating = dentist.User.Rating
             
            };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> patientEditInfo(PatientEditInfoViewModel editModel, Guid id)
        {
             string userId = GetCurrentUserId();
             var user = this.usersService.GetAllUsers().FirstOrDefault(u => u.Id == userId);

             var viewModel = new PatientEditInfoViewModel()
             {
                 FirstName = user.FirstName,
                 LastName = user.LastName,
                // Gender = user.Gender,
                 Email = user.Email,
                 EGN = user.EGN

             };

            if (user == null)
            {
                return this.Content("Story not found.");
            }

            if (this.ModelState.IsValid)
            {
                var userDto = new UserDTO()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    //user.Gender = editViewModel.Gender,
                    Email = user.Email,
                    EGN = user.EGN
                };
                //this.usersService.Edit(id, userDto);
            }

            return this.RedirectToAction("patientHomePage", "Patient");
        }
        public IActionResult patientFindDoctor()
        {
            return View();
        }

        public IActionResult patientMedicalManipulationsHistory()
        {
            return View();
        }
        [HttpGet]
        public IActionResult patientOnFirstLogIn(String returnurl = null)
        {
            string userId = GetCurrentUserId();
            var user = this.usersService.GetAllUsers().FirstOrDefault(u => u.Id == userId);

            var model = new PatientFirstLogInViewModel()
            {
                Gender = user.Gender,
                EGN = user.EGN.ToString()
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult patientOnFirstLogin(PatientFirstLogInViewModel model)
        {
            string userId = GetCurrentUserId();
            var user = this.usersService.GetAllUsers().FirstOrDefault(u => u.Id == userId);

            if (ModelState.IsValid)
            {
                user.EGN = Int64.Parse(model.EGN);
                user.Gender = model.Gender;
                usersService.Edit(user);

                return RedirectToAction("patientHomePage", "Patient");
            }
            return View(model);
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
