using AutoMapper;
using DentistAppointment.Data.Models;
using DentistAppointment.Models.CommentsViewModel;
using DentistAppointment.Models.DentistViewModels;
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
        // marto
        private readonly IReviewsService reviewsService;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public DentistController(
            IUsersService usersService,
            IDentistsService dentistsService,
            // marto
            IReviewsService reviewsService,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper,
            UserManager<User> userManager)
        {
            this.usersService = usersService;
            this.dentistsService = dentistsService;
            this.httpaccessor = httpContextAccessor;
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
            var reviews = reviewsService.GetAllByDentist(dentist.Id).ToList();
            float rating = 0;

            foreach(Review r in reviews)
            {
                rating += r.Rating/reviews.Count;
            }

            var viewModel = new DentistHomePageViewModel()
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
        public IActionResult dentistEditInfo(string returnUrl = null)
        {
            var user = this.usersService.GetAllUsers().FirstOrDefault(x => x.Id == GetCurrentUserId());
            var viewModel = new DentistEditInfoViewModel()
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
        public IActionResult dentistEditInfo(DentistEditInfoViewModel model)
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

            return this.RedirectToAction("dentistHomePage", "Dentist");
           // return View(viewModel);
        }

        [HttpGet]
        public IActionResult dentistFindAPatient(DentistFindAPatientViewModel model)
        {
            // Save input data into the model
            DentistFindAPatientViewModel inputModel = new DentistFindAPatientViewModel()
            {
                LastName = model.LastName,
                EGN = model.EGN,
                Email = model.Email
            };
            

            var patients = new List<User>();
            if (model != null)
            {
                if (!String.IsNullOrEmpty(inputModel.LastName))
                {
                    patients = usersService.GetAllUsersWithReservations().Where(u => u.LastName == inputModel.LastName).ToList();
                }
                else if (!String.IsNullOrEmpty(inputModel.Email))
                {
                    patients = usersService.GetAllUsersWithReservations().Where(u => u.Email == inputModel.Email).ToList();
                }
                else if (inputModel.EGN != 0)
                {
                    patients = usersService.GetAllUsersWithReservations().Where(u => u.EGN == inputModel.EGN).ToList();
                }
                else if(!String.IsNullOrEmpty(inputModel.LastName) && !String.IsNullOrEmpty(inputModel.Email))
                {
                    patients = usersService.GetAllUsersWithReservations()
                        .Where(u => u.LastName == inputModel.LastName && u.Email == inputModel.Email).ToList();
                }
                else if (!String.IsNullOrEmpty(inputModel.LastName) && inputModel.EGN != 0)
                {
                    patients = usersService.GetAllUsersWithReservations()
                        .Where(u => u.LastName == inputModel.LastName && u.EGN == inputModel.EGN).ToList();
                }
                else if (inputModel.EGN != 0 && !String.IsNullOrEmpty(inputModel.Email))
                {
                    patients = usersService.GetAllUsersWithReservations()
                        .Where(u => u.EGN == inputModel.EGN && u.Email == inputModel.Email).ToList();
                }
                else if (inputModel.EGN != 0 && !String.IsNullOrEmpty(inputModel.Email) && !String.IsNullOrEmpty(inputModel.LastName))
                {
                    patients = usersService.GetAllUsersWithReservations()
                        .Where(u => u.EGN == inputModel.EGN && u.Email == inputModel.Email && u.LastName == inputModel.LastName).ToList();
                }
                else
                {
                    if(String.IsNullOrEmpty(inputModel.LastName) || String.IsNullOrEmpty(inputModel.Email))
                    {
                        patients = usersService.GetAllUsersWithReservations().Where(u => u.EGN ==  inputModel.EGN).ToList();
                    }
                    else if(String.IsNullOrEmpty(inputModel.LastName) || inputModel.EGN == 0)
                    {
                        patients = usersService.GetAllUsersWithReservations().Where(u => u.Email == inputModel.Email).ToList();
                    }
                    else if (inputModel.EGN == 0 || String.IsNullOrEmpty(inputModel.Email))
                    {
                        patients = usersService.GetAllUsersWithReservations().Where(u => u.LastName == inputModel.LastName).ToList();
                    }


                }    
            }

            // If there is no input the list is empty (No patients are found)
            if(patients == null)
            {
                return View(inputModel);
            }
            else
            {
                return View(new DentistFindAPatientViewModel()
                {
                    LastName = model.LastName,
                    EGN = model.EGN,
                    Email = model.Email,
                    Patients = patients
                });
            }
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

        public IActionResult dentistEvents()
        {
            return View();
        }
    }
}
