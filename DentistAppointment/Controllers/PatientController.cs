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
using DentistAppointment.Models.PatientViewModels;

namespace DentistAppointment.Controllers
{
    [Authorize]
    public class PatientController : Controller
    {
        private readonly IHttpContextAccessor httpaccessor;
        private readonly IUsersService usersService;
        private readonly IDentistsService dentistsService;
        private readonly IReviewsService reviewsService;
        private readonly IReservationsService reservationsService;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public PatientController(
            IUsersService usersService,
            IDentistsService dentistsService,
             IReviewsService reviewsService,
            IHttpContextAccessor httpContextAccessor,
            IReservationsService reservationsService,
            IMapper mapper,
            UserManager<User> userManager)
        {
            this.usersService = usersService;
            this.dentistsService = dentistsService;
            this.reviewsService = reviewsService;
            this.reservationsService = reservationsService;
            this.httpaccessor = httpContextAccessor;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        private string GetCurrentUserId() => this.userManager.GetUserId(HttpContext.User);
        private int GetCurrentDentistId() => 1;
        public IActionResult patientHomePage()
        {
            string userId = GetCurrentUserId();
            var user = this.usersService.GetAllUsers().FirstOrDefault(u => u.Id == userId);
            var dentist = this.dentistsService.GetAllDentists().FirstOrDefault();
            //var reviews = this.reviewsService.GetAllByUser(user.Id);
            var reviews = reviewsService.GetAllByUser(user.Id, dentist.Id).ToList();
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
            string userId = GetCurrentUserId();
            var user = this.usersService.GetAllUsers().FirstOrDefault(x => x.Id == GetCurrentUserId());
            var dentist = this.dentistsService.GetAllDentists().FirstOrDefault();
            var allReservations = this.reservationsService.GetAllReservationsOfUser(user.Id,dentist.Id);

            var model = new PatientAppointmentsViewModel()
            {
                Reservations = allReservations.ToList()
            };

            return View(model);
        }
        public IActionResult patientBooking()
        {
            var model = new PatientBookingModel()
            {
                WorkHours = reservationsService.GetDentistWorkHoursForDay(GetCurrentDentistId(), DateTime.Now)
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult workHoursForDay(int year, int month, int day)
        {
            var model = new PatientBookingModel();

            if (year > 0 && month > 0 && day > 0)
            {
                model.WorkHours = reservationsService.GetDentistWorkHoursForDay(GetCurrentDentistId(), new DateTime(year, month, day));
            }
            return PartialView(model);
        }
        [HttpPost]
        public IActionResult patientBooking(PatientBookingModel model)
        {
            if (ModelState.IsValid)
            {
                DateTime date = new DateTime(model.Date.Year, model.Date.Month, model.Date.Day,
                                             model.Start.Hour, model.Start.Minute, model.Start.Second);
                reservationsService.MakeReservation(GetCurrentUserId(), GetCurrentDentistId(), date);
            }
            return RedirectToAction("patientBooking", "Patient");
        }
        public IActionResult patientCheckDocument(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("patientMedicalManipulationsHistory", "Patient");
            }

            var getReservation = this.reservationsService.GetReservationById(id);
            var result = new PatientCheckDocumentViewModel
            {
                Reservation = getReservation
            };
            return View(result);
        }
        public IActionResult patientDentistHomePage(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("patientFindDoctor", "Patient");
            }
            string userId = GetCurrentUserId();
            var getDentistId = this.dentistsService
                 .GetAllDentists().FirstOrDefault(user => user.User.Id == userId);
            var result = new PatientDentistHomePageViewModel
            {
                Dentist = getDentistId
               
            };
            return View(result);
            /*  string userId = GetCurrentUserId();
             int dentistId = GetCurrentDentistId();
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
                  Type = dentist.Type
                 // Rating = rating,
                 // Reviews = reviews
              };
              //Console.WriteLine(reviews);

              return View(viewModel);*/
            //return View(); 
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
                else if (!double.IsNormal(inputModel.Rating))
                {
                    dentists = dentistsService.GetAllDentists().Where(d => d.User.Rating == inputModel.Rating).ToList();
                }
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
                if (!String.IsNullOrEmpty(inputModel.LastName) && !String.IsNullOrEmpty(inputModel.Type))
                {
                    dentists = dentistsService.GetAllDentists()
                        .Where(d => d.User.LastName == inputModel.LastName && d.Type == inputModel.Type).ToList();
                }
                else if (!String.IsNullOrEmpty(inputModel.LastName) && !String.IsNullOrEmpty(inputModel.Type) && !String.IsNullOrEmpty(inputModel.City))
                {
                    dentistsService.GetAllDentists()
                        .Where(d => d.User.LastName == inputModel.LastName && d.Type == inputModel.Type && d.City == inputModel.City).ToList();
                }
            }

            // If there is no input the list is empty (No dentists are found)
            if (dentists == null)
            {
                return View(inputModel);
            }
            else
            {
                string userId = GetCurrentUserId();
                var user = this.usersService.GetAllUsers().FirstOrDefault(u => u.Id == userId);
                var dentist = this.dentistsService.GetAllDentists().FirstOrDefault();
                //var reviews = this.reviewsService.GetAllByUser(user.Id);
                var reviews = reviewsService.GetAllByUser(user.Id,dentist.Id).ToList();
                float rating = 0;
                foreach (Review r in reviews)
                {
                    rating += r.Rating / reviews.Count;
                }
                return View(new PatientFindDentistViewModel()
                {
                    City = model.City,
                    Type = model.Type,
                    LastName = model.LastName,
                    Rating = rating,
                    Dentists = dentists
                });
            }
        }
         public IActionResult patientMedicalManipulationsHistory()
         {
              string userId = GetCurrentUserId();
             var user = this.usersService.GetAllUsers().FirstOrDefault(x => x.Id == GetCurrentUserId());
             var dentist = this.dentistsService.GetAllDentists().FirstOrDefault();
             var allReservations = this.reservationsService.GetAllReservationsOfUser(user.Id,dentist.Id);

             var model = new PatientMedicalManipulationsHistoryViewModel()
             {
                 Reservations = allReservations.ToList()
             };

             return View(model);
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
