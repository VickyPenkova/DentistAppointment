using DentistAppointment.Data.Models;
using DentistAppointment.Models.CommentsViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistAppointment.Models.DentistViewModels
{
    public class DentistHomePageViewModel
    {
        public User User { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
        public double Rating { get; set; }
    }
}