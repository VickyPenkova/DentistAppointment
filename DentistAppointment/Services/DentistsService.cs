using DentistAppointment.Data;
using DentistAppointment.Data.Models;
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
        private readonly IRepository<User, int> usersRepo;
        private readonly IRepository<Reservation, int> reservationsRepo;

        // To be used in Dentist Controller 
        // For ex: For the Dentist Profile

        public Dentist GetDentistById(int dentistId)
        {
            return dentistsRepo.GetById(dentistId);
        }

        public IEnumerable<Dentist> GetAllDentists()
        {
            return dentistsRepo.GetAll();
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
    }
}
