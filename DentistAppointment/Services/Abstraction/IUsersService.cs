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
        Guid Edit(Guid id, UserDTO user);
        User GetUserById(string userId);
    }
}
