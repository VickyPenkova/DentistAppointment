using DentistAppointment.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistAppointment.Services.Abstraction
{
    public interface ICommentsService
    {
        IEnumerable<Comment> GetAllComments();
        IEnumerable<Comment> GetAllCommentsOfDentist(int dentistId);
       // IEnumerable<Comment> GetAllCommentsOfPatient(string userId);
    }
}
