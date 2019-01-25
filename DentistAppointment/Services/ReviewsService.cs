using DentistAppointment.Data;
using DentistAppointment.Data.Models;
using DentistAppointment.Services.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DentistAppointment.Services
{
    public class ReviewsService : IReviewsService
    {
        private readonly IRepository<User, string> usersRepo;
        private readonly IRepository<Dentist, int> dentistsRepo;
        private readonly ReviewRepository reviewsRepo;
        private readonly IRepository<Reservation, int> reservationsRepo;

        public ReviewsService(
            IRepository<User, string> usersRepo,
            IRepository<Dentist, int> dentistsRepo,
            ReviewRepository reviewsRepo,
             IRepository<Reservation, int> reservationsRepo)
        {
            this.usersRepo = usersRepo;
            this.dentistsRepo = dentistsRepo;
            this.reviewsRepo = reviewsRepo;

            this.reservationsRepo = reservationsRepo;
        }

        public IEnumerable<Review> GetAllByUser(int dentistId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Review> GetAllByDentist(int dentistId)
        {
            var reviews = this.reviewsRepo.GetByDentistId(dentistId);
            foreach (var review in reviews)
            {
                review.User = usersRepo.GetById(review.UserId);
            }

            return reviews;
        }
        public IEnumerable<Review> GetAllByUser(string userId, int dentistId)
        {
            var reviews = this.reviewsRepo.GetByUserId(userId);
            foreach (var review in reviews)
            {
                review.User.Dentist = dentistsRepo.GetById(review.User.Dentist.Id);
            }

            return reviews;
        }
        public IEnumerable<Review> GetAllReviews()
        {
            throw new NotImplementedException();
        }

        public string GetContentOfReview(int reviewId)
        {
            throw new NotImplementedException();
        }

        public Review GetUserReviewForReservation(Reservation reservation)
        {
            return reviewsRepo.GetAll().First(review => review.ReservationId == reservation.Id && review.UserId == reservation.UserId);
        }


        public void AddReviewForDentist(Review review)
        {
            // Add the rating to dentist profile
            var reservation = reservationsRepo.GetById(review.ReservationId);
            var user = usersRepo.GetAll().First(u => u.DentistId == reservation.DentistId);
            user.Rating += review.Rating;
            user.Rating /= 2;
            usersRepo.Update(user);
            usersRepo.Save();

            reviewsRepo.Add(review);
            reviewsRepo.Save();
        }

    }
}
