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
        IEnumerable<Review> GetAllByDentist(int dentistId);
        IEnumerable<Review> GetAllByUser(string userId, int dentistId);
        Review GetUserReviewForReservation(Reservation reservation);
        void AddReviewForDentist(Review review);
        string GetContentOfReview(int reviewId);
    }
}
