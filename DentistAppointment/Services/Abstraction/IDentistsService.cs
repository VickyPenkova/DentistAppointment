using DentistAppointment.Data.Models;
using DentistAppointment.Models.AdminViewModels;
using DentistAppointment.Models.DentistViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistAppointment.Services.Abstraction
{
    public interface IDentistsService
    {
        Dentist GetDentistById(int dentistId);
        IEnumerable<Dentist> GetAllDentists();
        IEnumerable<User> GetAllDentistsPatience(int dentistId);
        IEnumerable<Reservation> GetAllReservationsOfDentist(int dentistId);
        User GetDentistByUserId(string userId);
        void Edit(User user);
        void Edit(Dentist dentist);
        void Save(AddDentistViewModel addDentistViewModel);
        void editDocumentManipulation(DentistDocumentManipulationViewModel dentistDocument, int reservationId);
    }
}
