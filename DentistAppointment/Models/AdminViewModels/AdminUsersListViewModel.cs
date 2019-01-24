using DentistAppointment.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistAppointment.Models.AdminViewModels
{
    public class AdminUsersListViewModel
    {
        public string UserToBlockId { get; set; }

        public List<User> Users { get; set; }

        public int Blocked { get; set; } = 0;

        // Just in case :)
        //public int CurrentPage { get; set; }

        //public int TotalPages { get; set; }

        //public string CurrentUrl { get; set; }

        //public string SearchByName { get; set; }
    }
}
