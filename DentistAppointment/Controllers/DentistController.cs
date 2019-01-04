using AutoMapper;
using DentistAppointment.Data.Models;
using DentistAppointment.Models.CommentsViewModel;
using DentistAppointment.Models.DentistViewModel;
using DentistAppointment.Services;
using DentistAppointment.Services.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DentistAppointment.Controllers
{
    public class DentistController : Controller
    {
        private readonly IHttpContextAccessor httpaccessor;
        private readonly IUsersService usersService;
        private readonly IDentistsService dentistsService;
        private readonly ICommentsService commentsService;
        // marto
        private readonly IReviewsService reviewsService;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public DentistController(
            IUsersService usersService,
            IDentistsService dentistsService,
            ICommentsService commentsService,
            // marto
            IReviewsService reviewsService,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper,
            UserManager<User> userManager)
        {
            this.usersService = usersService;
            this.dentistsService = dentistsService;
            this.httpaccessor = httpContextAccessor;
            this.commentsService = commentsService;
            // marto
            this.reviewsService = reviewsService;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public IActionResult index()
        {
            return View();
        }

        private string GetCurrentUserId() => this.userManager.GetUserId(HttpContext.User);

        public IActionResult dentistHomePage()
        {

            string userId = GetCurrentUserId();
            var dentist = this.dentistsService
                .GetAllDentists().FirstOrDefault(user => user.User.Id == userId);
            var comments = commentsService.GetAllCommentsOfDentist(dentist.Id).ToList();
            // marto
            var reviews = reviewsService.GetAllByDentist(dentist.Id).ToList();
            
            var viewModel = new DentistHomePageViewModel()
            {
                User = this.usersService.GetAllUsers().FirstOrDefault(x => x.Dentist == dentist),
                Address = dentist.Address,
                Type = dentist.Type,
                Rating = dentist.User.Rating,
                Comments = comments,
                // marto
                Reviews = reviews
            };

            return View(viewModel);
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
