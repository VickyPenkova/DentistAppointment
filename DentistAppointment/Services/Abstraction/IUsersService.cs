﻿using DentistAppointment.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistAppointment.Services.Abstraction
{
    public interface IUsersService
    {
        IEnumerable<User> GetAllUsers();
    }
}
