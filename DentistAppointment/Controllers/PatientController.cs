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
        private readonly IReviewsService reviewsService;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public PatientController(
            IUsersService usersService,
            IDentistsService dentistsService,
             IReviewsService reviewsService,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper,
            UserManager<User> userManager)
        {
            this.usersService = usersService;
            this.dentistsService = dentistsService;
            this.reviewsService = reviewsService;
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

        private string GetCurrentUserId() => this.userManager.GetUserId(HttpContext.User);
        public IActionResult patientHomePage()
        {
            string userId = GetCurrentUserId();
            var user = this.usersService.GetAllUsers().FirstOrDefault(u => u.Id == userId);
            var reviews = reviewsService.GetAllByUser(user.Id).ToList();
            float rating = 0;
            foreach (Review r in reviews)
            {
                rating += r.Rating / reviews.Count;
            }

            var viewModel = new PatientHomePageViewModel()
            {
                User = this.usersService.GetAllUsers().FirstOrDefault(),
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                 Email = user.Email,
                 EGN = user.EGN,
                Rating = rating,
                Reviews = reviews

            };
            Console.WriteLine(reviews);
            
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
            string userId = GetCurrentUserId();
            var dentist = this.dentistsService
                .GetAllDentists().FirstOrDefault(user => user.User.Id == userId);
            var reviews = reviewsService.GetAllByDentist(dentist.Id).ToList();
            float rating = 0;
            foreach (Review r in reviews)
            {
                rating += r.Rating / reviews.Count;
            }

            var viewModel = new PatientDentistHomePageViewModel()
            {
                User = this.usersService.GetAllUsers().FirstOrDefault(x => x.Dentist == dentist),
                Address = dentist.Address,
                Type = dentist.Type,
                Rating = rating,
                Reviews = reviews
            };
            Console.WriteLine(reviews);

            return View(viewModel);
            
        }
        [HttpGet]
        public IActionResult patientEditInfo(string returnUrl = null)
        {
            string userId = GetCurrentUserId();
            var user = this.usersService.GetAllUsers().FirstOrDefault(u => u.Id == userId);
            var viewModel = new PatientEditInfoViewModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                EGN = user.EGN.ToString(),
                Email = user.Email,
                Gender = user.Gender
            };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult patientEditInfo(PatientEditInfoViewModel model)
        {
            var user = this.usersService.GetAllUsers().FirstOrDefault(x => x.Id == GetCurrentUserId());

            if (this.ModelState.IsValid)
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.EGN = Int64.Parse(model.EGN);
                user.Gender = model.Gender;

                this.dentistsService.Edit(user);
            }

            return this.RedirectToAction("patientHomePage", "Patient");
        }
       
        [HttpGet]
        public IActionResult patientFindDoctor(PatientFindDentistViewModel model)
        {
            // Save input data into the model
            PatientFindDentistViewModel inputModel = new PatientFindDentistViewModel()
            {
                City = model.City,
                Type = model.Type,
                LastName = model.LastName,
                Rating = model.Rating
            };

            var dentists = new List<Dentist>();
            if (model != null)
            {
                if (!String.IsNullOrEmpty(inputModel.LastName))
                {
                    dentists = dentistsService.GetAllDentists().Where(d => d.User.LastName == inputModel.LastName).ToList();
                }
                else if (!String.IsNullOrEmpty(model.Type))
                {
                    dentists = dentistsService.GetAllDentists().Where(d => d.Type == inputModel.Type).ToList();
                }
                else if (!String.IsNullOrEmpty(inputModel.City))
                {
                    dentists = dentistsService.GetAllDentists().Where(d => d.City == inputModel.City).ToList();
                }
                /* else if (!String.IsNullOrEmpty(inputModel.Rating))
                 {
                     dentists = dentistsService.GetAllDentists().Where(d => d.User.Rating == inputModel.Rating).ToList();
                 }*/
                if (!String.IsNullOrEmpty(inputModel.City) && !String.IsNullOrEmpty(inputModel.Type))
                    {
                    dentists = dentistsService.GetAllDentists()
                    .Where(d => d.City == inputModel.City && d.Type == inputModel.Type).ToList();
                }
               if (!String.IsNullOrEmpty(inputModel.City) && !String.IsNullOrEmpty(inputModel.LastName))
                {
                    dentists = dentistsService.GetAllDentists()
                    .Where(d => d.City == inputModel.City && d.User.LastName == inputModel.LastName).ToList();
                }
                else if (!String.IsNullOrEmpty(inputModel.LastName) && !String.IsNullOrEmpty(inputModel.Type))
                {
                    dentists = dentistsService.GetAllDentists()
                        .Where(d => d.User.LastName == inputModel.LastName && d.Type == inputModel.Type).ToList();
                }

               
            }

            // If there is no input the list is empty (No dentists are found)
            if (dentists == null)
            {
                return View(inputModel);
            }
            else
            {
                return View(new PatientFindDentistViewModel()
                {
                    City = model.City,
                    Type = model.Type,
                    LastName = model.LastName,
                    Rating = model.Rating,
                    Dentists = dentists
                });
            }
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
