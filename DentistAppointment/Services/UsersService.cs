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

        public IEnumerable<UserDTO> GetUsers(int count)
        {
            var usersFromDb = this.usersRepo
                .GetAll()
                .Take(count)
                .ToList();

            List<UserDTO> users = new List<UserDTO>();

            users = this.mapper.Map<List<UserDTO>>(usersFromDb);

            return users;
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


        public IEnumerable<UserDTO> GetUserInfo(string userId)
        {
            
            var user = this.usersRepo.GetAll()
                .Include(model => model.FirstName)
                .Include(model => model.LastName)
                .Include(model => model.Email)
                .Include(model => model.Gender)
                .Include(model => model.EGN)
                .FirstOrDefault(u => u.Id == userId);
            var userInfo = user.FirstName;

            return this.mapper.Map<List<UserDTO>>(user);
        }
        public void Edit(User user)
        {
            usersRepo.Update(user);
            usersRepo.Save();
        }
        public IEnumerable<Reservation> GetAllReservationsOfDentist(int dentistId)
        {
            return new List<Reservation>(reservationsRepo.GetAll()
                .Include(dentist => dentist.Dentist)
                .Where(d => d.DentistId == dentistId));
        }

        // To be used only by Admin!
        public void Delete(User user)
        {
            usersRepo.Delete(user);
            usersRepo.Save();
        }
    }
}
