using DentistAppointment.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistAppointment.Services.Abstraction
{
    public interface IReviewsService
    {
        IEnumerable<Review> GetAllReviews();
        IEnumerable<Review> GetAllByUser(int dentistId);
        string GetContentOfReview(int reviewId);
    }
}
