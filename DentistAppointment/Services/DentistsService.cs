using DentistAppointment.Data;
using DentistAppointment.Data.Models;
using DentistAppointment.Models.AdminViewModels;
using DentistAppointment.Models.DentistViewModels;
using DentistAppointment.Services.Abstraction;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

// To be later used in DentistController

namespace DentistAppointment.Services
{
    public class DentistsService : IDentistsService
    {
        private readonly IRepository<Dentist, int> dentistsRepo;
        private readonly IRepository<User, string> usersRepo;
        private readonly IRepository<Reservation, int> reservationsRepo;

        // Constructor DI
        public DentistsService(
            IRepository<Dentist,int> dentistsRepo,
            IRepository<User, string> usersRepo,
            IRepository<Reservation, int> reservationsRepo)
        {
            this.dentistsRepo = dentistsRepo;
            this.usersRepo = usersRepo;
            this.reservationsRepo = reservationsRepo;
        }


        public Dentist GetDentistById(int dentistId)
        {
            return dentistsRepo.GetById(dentistId);
        }

        public User GetDentistByUserId(string userId)
        {
            return usersRepo.GetById(userId);
        }

        public IEnumerable<Dentist> GetAllDentists()
        {
            return dentistsRepo.GetAll().Include(d => d.User);
        }

        // List of patients
        public IEnumerable<User> GetAllDentistsPatience(int dentistId)
        {
            return new List<User>(usersRepo.GetAll()
                .Include(dentist => dentist.Dentist)
                .Where(u => u.DentistId == dentistId));
        }

        public IEnumerable<Reservation> GetAllReservationsOfDentist(int dentistId)
        {
            return new List<Reservation>(reservationsRepo.GetAll()
                .Include(dentist => dentist.Dentist)
                .Where(d => d.DentistId == dentistId));
        }

        public void Edit(User user)
        {
            this.usersRepo.Update(user);
            this.usersRepo.Save();
        }

        public void Edit(Dentist dentist)
        {
            this.dentistsRepo.Update(dentist);
            this.dentistsRepo.Save();
        }

        public void Save(AddDentistViewModel addDentistViewModel)
        {
            // TODO: Create new viewModel to pass to Save() that initializes both User and Dentist
            User user = new User()
            {
                FirstName = addDentistViewModel.FirstName,
                LastName = addDentistViewModel.LastName,
                UserName = addDentistViewModel.EmailAndUserName,
                Email = addDentistViewModel.EmailAndUserName,
                PhoneNumber = addDentistViewModel.PhoneNumber             
            };

            Dentist dentist = new Dentist()
            {
                Address = addDentistViewModel.Address,
                City = addDentistViewModel.City,
                User = user
            };

            this.usersRepo.Add(user);
            this.usersRepo.Save();

            this.dentistsRepo.Add(dentist);
            this.dentistsRepo.Save();
        }

        public void editDocumentManipulation(DentistDocumentManipulationViewModel dentistDocument, int reservationId)
        {
            //var reservation = this.reservationsRepo.GetById(dentistDocument.Reservation.Id);
            var reservation = this.reservationsRepo.GetAll()
                .Include(x => x.User)
                .FirstOrDefault(x => x.Id == reservationId);
            var userToRate = this.usersRepo.GetById(reservation.User.Id);

            reservation.Manipulation = dentistDocument.Reservation.Manipulation;
            this.reservationsRepo.Save();

            userToRate.Rating = dentistDocument.Reservation.User.Rating;
            this.usersRepo.Save();
        }
    }
}
