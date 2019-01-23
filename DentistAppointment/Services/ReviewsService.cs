﻿using DentistAppointment.Data;
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

        //public IEnumerable<Review> GetAllByDentist(int dentistId)
        //{
        //    var reservations = this.reservationsRepo
        //        .GetAll()
        //        .Include(x => x.User)
        //        .Where(x => x.DentistId == dentistId).ToList();
        //    var reviewsForDentist = new List<Review>();

        //    foreach (var r in reservations)
        //    {
        //        reviewsForDentist.AddRange(reviewsRepo
        //        .GetAll()
        //        .Include(x => x.User)
        //        .Where(c => c.ReservationId == r.Id && c.User.DentistId == null).ToList());
        //    }

        //    return reviewsForDentist;
        //}

        public IEnumerable<Review> GetAllByDentist(int dentistId)
        {
            var reviews =this.reviewsRepo.GetByDentistId(dentistId);
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
        /* public IEnumerable<Review> GetAllByUser(string userId)
         {
             var reviews = this.reviewsRepo.GetByUserId(userId);
             foreach (var review in reviews)
             {
                 review.User.Dentist = dentistsRepo.GetById(review.User.Dentist.Id);
             }

             return reviews;
         }*/
        /* public IEnumerable<Review> GetAllByUser(string userId)
         {
             var reservations = this.reservationsRepo
                 .GetAll()
                 .Include(x => x.User.Dentist)
                 .Where(x => x.UserId == userId).ToList();
             var reviewsForUser = new List<Review>();

             foreach (var r in reservations)
             {
                 reviewsForUser.AddRange(reviewsRepo
                 .GetAll()
                 .Include(x => x.User.Dentist)
                 .Where(c => c.ReservationId == r.Id && c.UserId == null).ToList());
             }

             return reviewsForUser;
         }*/

        public IEnumerable<Review> GetAllReviews()
        {
            throw new NotImplementedException();
        }

        public string GetContentOfReview(int reviewId)
        {
            throw new NotImplementedException();
        }
      /*  public string GetContentOfReview(string reviewId)
        {
            throw new NotImplementedException();
        }*/
    }
}
