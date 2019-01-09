using DentistAppointment.Data.Models;
using DentistAppointment.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistAppointment.Services.Abstraction
{
    public interface IUsersService
    {
        IEnumerable<User> GetAllUsers();
        void Edit(User user);
        User GetUserById(string userId);
        IEnumerable<Reservation> GetAllReservationsOfUser(string userId);


    }
}
