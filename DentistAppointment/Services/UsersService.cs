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
        private readonly IRepository<DentistAppointment.Data.Models.User, string> usersRepo;
        private readonly IMapper mapper;

        public UsersService(IRepository<User, string> usersRepo, IMapper mapper)
        {
            this.usersRepo = usersRepo;
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
            return this.usersRepo
                .GetById(userId);

            //return this.mapper.Map<UserDTO>(userFromDb);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return usersRepo.GetAll();
        }

        public IEnumerable<UserDTO> GetUserInfo(string userId)
        {
            var user = this.usersRepo.GetAll()
                .Include(model => model.FirstName)
                .Include(model => model.LastName)
                .Include(model => model.Email)
                .Include(model => model.Gender)
                .Include(model => model.EGN)
               // .Include(model => model.Address)
                .FirstOrDefault(u => u.Id == userId);
            var userInfo = user.FirstName;

            return this.mapper.Map<List<UserDTO>>(user);
        }
    }
}
