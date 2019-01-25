using AutoMapper;
using DentistAppointment.Data;
using DentistAppointment.Data.Models;
using DentistAppointment.DTOs;
using DentistAppointment.Services.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DentistAppointment.Services
{
    public class UsersService : IUsersService
    {
        private readonly IRepository<Dentist, int> dentistsRepo;
        private readonly IRepository<User, string> usersRepo;
        private readonly IRepository<Reservation, int> reservationsRepo;
        private readonly IMapper mapper;

        public UsersService(IRepository<Dentist, int> dentistsRepo,
            IRepository<User, string> usersRepo,
            IRepository<Reservation, int> reservationsRepo, IMapper mapper)
        {
            this.dentistsRepo = dentistsRepo;
            this.usersRepo = usersRepo;
            this.reservationsRepo = reservationsRepo;
            this.mapper = mapper;
        }

        public User GetUserById(string userId)
        {
            return usersRepo.GetById(userId);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return usersRepo.GetAll();
        }

        public IEnumerable<User> GetAllUsersWithReservations()
        {
            return usersRepo.GetAll().Include(x => x.Reservations).Where(p => p.DentistId == null && p.Email != "admin@gmail.com");
        }

        public void Edit(User user)
        {
            usersRepo.Update(user);
            usersRepo.Save();
        }
        public IEnumerable<Reservation> GetAllReservationsOfUser(string userId)
        {
            return new List<Reservation>(reservationsRepo.GetAll()
                .Include(user => user.User)
                .Where(u => u.UserId == userId));
        }

        // To be used only by Admin!
        public void Delete(User user)
        {
            usersRepo.Delete(user);
            usersRepo.Save();
        }
    }
}
