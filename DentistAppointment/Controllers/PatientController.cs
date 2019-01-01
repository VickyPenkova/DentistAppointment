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

namespace DentistAppointment.Controllers
{
   [Authorize]
    public class PatientController:Controller
    {
        private readonly IHttpContextAccessor httpaccessor;
        private readonly IUsersService usersService;
        private readonly IDentistsService dentistsService;
        private readonly ICommentsService commentsService;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public PatientController(
            IUsersService usersService,
            IDentistsService dentistsService,
            ICommentsService commentsService,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper,
            UserManager<User> userManager)
        {
            this.usersService = usersService;
            this.dentistsService = dentistsService;
            this.httpaccessor = httpContextAccessor;
            this.commentsService = commentsService;
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
           // var comments = commentsService.GetAllCommentsOfPatient(user.Id).ToList();

            var viewModel = new PatientHomePageViewModel()
            {
                User = this.usersService.GetAllUsers().FirstOrDefault(u => u.Id == userId),
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                 Rating=user.Rating,
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
            string userId = GetCurrentUserId();
            var user = this.usersService.GetAllUsers().FirstOrDefault(u => u.Id == userId);

            var viewModel = new PatientEditInfoViewModel()
            {
                User = this.usersService.GetAllUsers().FirstOrDefault(u => u.Id == userId),
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                Email = user.Email,
                EGN = user.EGN

            };

            return View(viewModel);
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
