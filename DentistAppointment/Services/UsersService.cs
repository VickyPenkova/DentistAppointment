using DentistAppointment.Data;
using DentistAppointment.Data.Models;
using DentistAppointment.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DentistAppointment.Services
{       
    public class UsersService : IUsersService
    {
        private readonly GenericRepository<User, string> usersRepo;
        private readonly GenericRepository<Dentist, int> dentistRepo;

        public UsersService(GenericRepository<User, string> usersRepo)
        {
            this.usersRepo = usersRepo;
        }

        // Login page that checks if the user is a Dentist or a Patient
        public Object isTheUserDentist(string password)
        {
            var dentistId = this.usersRepo
                .GetAll()
                .FirstOrDefault(p => p.PasswordHash == password).DentistId;

            // If there is a dentist id than the user is dentist
            if(dentistId != null)
            {
                return true;
            }else
            {
                return false;
            }
        }

    }
}
