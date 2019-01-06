using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DentistAppointment.Common;
using DentistAppointment.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Dbmodel = DentistAppointment.Data.Models;

namespace DataSeed
{
    public class DbInitializer
    {
        private IServiceProvider serviceProvider;
        private DentistAppointmentDbContext context;

        public DbInitializer(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            context = this.serviceProvider.GetRequiredService<DentistAppointmentDbContext>();
        }

        public void Initialize()
        {
            context.Database.Migrate();
            AddRoles();
            SeedUsers();
            SeedDentists();
            SeedReservations();
            SeedReviews();
            SeedEvents();
            SeedComments();
            SeedBlacklist();
        }

        private void AddRoles()
        {
            Console.WriteLine("Adding roles...");
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var roleCheck = roleManager.RoleExistsAsync(GlobalConstants.AdminRole).Result;

            if (!roleCheck)
            {
                roleManager.CreateAsync(new IdentityRole(GlobalConstants.AdminRole)).Wait();
            }

            roleCheck = roleManager.RoleExistsAsync(GlobalConstants.UserRole).Result;
            if (!roleCheck)
            {
                roleManager.CreateAsync(new IdentityRole(GlobalConstants.UserRole)).Wait();
            }

            roleCheck = roleManager.RoleExistsAsync(GlobalConstants.DentistRole).Result;
            if (!roleCheck)
            {
                roleManager.CreateAsync(new IdentityRole(GlobalConstants.DentistRole)).Wait();
            }
        }

        private void SeedUsers()
        {
            Console.WriteLine("Adding users...");
            var userManager = this.serviceProvider.GetRequiredService<UserManager<Dbmodel.User>>();
            var adminUser = new Dbmodel.User
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                FirstName = "Admin",
                LastName = "Admin",
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = userManager.CreateAsync(adminUser, "qwerty123@").Result;
            userManager.AddToRoleAsync(adminUser, GlobalConstants.AdminRole).Wait();

            // The security stamp is used to invalidate a users login cookie and force them to re-login.
            var users = new List<Dbmodel.User>()
            {
                new Dbmodel.User
                {
                    UserName = "peter@gmail.com",
                    Email = "peter@gmail.com",
                    FirstName = "Peter",
                    LastName = "Petkov",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Gender = "male",
                    HealthCard = 123456,
                    EGN = 9507130000
                },
                new Dbmodel.User
                {
                    UserName = "george@gmail.com",
                    Email = "george@gmail.com",
                    FirstName = "George",
                    LastName = "Mingle",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    HealthCard = 123456,
                    EGN = 9508230001
                }
            };

            foreach (var user in users)
            {
                userManager.CreateAsync(user, "qwerty123@").Wait();
                userManager.AddToRoleAsync(user, GlobalConstants.UserRole).Wait();
            }
        }

        private void SeedDentists()
        {
            Console.WriteLine("Adding dentists...");
            var userManager = serviceProvider.GetRequiredService<UserManager<Dbmodel.User>>();

            var dentists = new List<Dbmodel.Dentist>()
            {
                new Dbmodel.Dentist
                {
                    City = "Sofia",
                    Address = "Lyulin 6",
                    Type = "Orthodontist",
                    WorkTimeStart = new TimeSpan(8, 0, 0),
                    WorkTimeEnd = new TimeSpan(13, 0, 0),
                    WorkDays = 42
                },
                new Dbmodel.Dentist
                {
                    City = "Plovdiv",
                    Address = "Kapana",
                    Type = "Surgeon",
                    WorkTimeStart = new TimeSpan(13, 0, 0),
                    WorkTimeEnd = new TimeSpan(18, 0, 0),
                    WorkDays = 84
                }
            };
            context.Dentists.AddRange(dentists);
            context.SaveChanges();

            // Get keys of inserted dentists
            var ids = new List<int>();
            foreach (var dentist in context.Dentists)
            {
                ids.Add(dentist.Id);
            }

            var users = new List<Dbmodel.User>()
            {
                new Dbmodel.User
                {
                    UserName = "ivan@gmail.com",
                    Email = "ivan@gmail.com",
                    FirstName = "Ivan",
                    LastName = "Ivanov",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    DentistId = ids[0]
                },
                new Dbmodel.User
                {
                    UserName = "stanimir@gmail.com",
                    Email = "stanimir@gmail.com",
                    FirstName = "Stanimir",
                    LastName = "Stoilov",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    DentistId = ids[1]
                }
            };

            foreach (var user in users)
            {
                userManager.CreateAsync(user, "qwerty123@").Wait();
                userManager.AddToRoleAsync(user, GlobalConstants.DentistRole).Wait();
            }
        }

        private void SeedReviews()
        {
            Console.WriteLine("Adding reviews...");

            List<Dbmodel.User> users = context.Users.Where
                (u => u.Email != null).ToList();
            List<Dbmodel.Review> reviews = new List<Dbmodel.Review>()
            {
                new Dbmodel.Review
                {
                    User = context.Users.FirstOrDefault(u => u.Email == "peter@gmail.com"),
                    Content = "Great service. Real professional",
                    Date = DateTime.Now,
                    Reservation = context.Reservations.Where(r => r.Dentist.User.Email == "ivan@gmail.com" && 
                                                                  r.User.Email == "peter@gmail.com").ToList()[0],
                    Rating = 5
                },
                new Dbmodel.Review
                {
                    User = context.Users.FirstOrDefault(u => u.Email == "george@gmail.com"),
                    Content = "Not satisfied. There was pain during manipulation",
                    Date = new DateTime(2018, 10, 31),
                    Reservation = context.Reservations.Where(r => r.Dentist.User.Email == "ivan@gmail.com" &&
                                                                  r.User.Email == "george@gmail.com").ToList()[0],
                    Rating = 1
                },
                new Dbmodel.Review
                {
                    User = context.Users.FirstOrDefault(u => u.Email == "ivan@gmail.com"),
                    Content = "Great customer",
                    Date = new DateTime(2018, 11, 1),
                    Reservation = context.Reservations.Where(r => r.User.Email == "peter@gmail.com" &&
                                                                  r.Dentist.User.Email == "ivan@gmail.com").ToList()[0],
                    Rating = 5
                },
                new Dbmodel.Review
                {
                    User = context.Users.FirstOrDefault(u => u.Email == "peter@gmail.com"),
                    Content = "Quality service from this dentist",
                    Date = DateTime.Now,
                    Reservation = context.Reservations.Where(r => r.Dentist.User.Email == "stanimir@gmail.com" &&
                                                                  r.User.Email == "peter@gmail.com").ToList()[0],
                    Rating = 3.5f
                }
            };

            context.Reviews.AddRange(reviews);
            context.SaveChanges();
        }
        
        private void SeedReservations()
        {
            Console.WriteLine("Adding reservations...");
            List<Dbmodel.User> users = context.Users.Where
                (u => u.Email != null).ToList();
            List<Dbmodel.Dentist> dentists = context.Dentists.ToList();

            List<Dbmodel.Reservation> reservations = new List<Dbmodel.Reservation>()
            {
                new Dbmodel.Reservation
                {
                    User = context.Users.FirstOrDefault(u => u.Email == "peter@gmail.com"),
                    Dentist = dentists.FirstOrDefault(u => u.Type == "Orthodontist"),
                    Manipulation = "Filling of 6C",
                    Date = DateTime.Now
                },
                new Dbmodel.Reservation
                {
                    User = context.Users.FirstOrDefault(u => u.Email == "george@gmail.com"),
                    Dentist = dentists.FirstOrDefault(u => u.Type == "Orthodontist"),
                    Manipulation = "Extraction of upper left wise tooth",
                    Date = new DateTime(2018, 10, 15)
                },
                new Dbmodel.Reservation
                {
                    User = context.Users.FirstOrDefault(u => u.Email == "peter@gmail.com"),
                    Dentist = dentists.FirstOrDefault(u => u.Type == "Surgeon"),
                    Manipulation = "Bridge between the front 2 and 3",
                    Date = new DateTime(2018, 11, 2)
                }
            };

            context.Reservations.AddRange(reservations);
            context.SaveChanges();
        }

        private void SeedEvents()
        {
            Console.WriteLine("Adding events...");          
            List<Dbmodel.Dentist> dentists = context.Dentists.ToList();
  
            List<Dbmodel.Event> events = new List<Dbmodel.Event>()
            {
                new Dbmodel.Event
                {
                    Dentist = dentists.FirstOrDefault(u => u.Type == "Orthodontist"),
                    Description = "Free checks week between 12.11.2018 and 19.11.2018",
                    StartDate = new DateTime(2018, 11, 12),
                    EndDate = new DateTime(2018, 11, 19)
                },
                new Dbmodel.Event
                {
                    Dentist = dentists.FirstOrDefault(u => u.Type == "Surgeon"),
                    Description = "Free teeth whitening with every other procedure",
                    StartDate = new DateTime(2018, 11, 15),
                    EndDate = new DateTime(2018, 11, 25)
                }
            };

            context.Events.AddRange(events);
            context.SaveChanges();
        }

        private void SeedComments()
        {
            Console.WriteLine("Adding comments...");

            List<Dbmodel.User> users = context.Users.Where
                (u => u.Email != null).ToList();
            List<Dbmodel.Event> events = context.Events.ToList();

            List<Dbmodel.Comment> comments = new List<Dbmodel.Comment>()
            {
                new Dbmodel.Comment
                {
                    User = users.FirstOrDefault(u => u.Email == "peter@gmail.com"),
                    Event = events.FirstOrDefault(),
                    Content = "Good quality service. Just in time needed."
                },
                new Dbmodel.Comment
                {
                    User = users.FirstOrDefault(u => u.Email == "george@gmail.com"),
                    Event = events.FirstOrDefault(),
                    Content = "Good quality service. Just in time needed."
                }
            };

            context.Comments.AddRange(comments);
            context.SaveChanges();
        }

        private void SeedBlacklist()
        {
            Console.WriteLine("Adding blacklist...");
            List<Dbmodel.User> users = context.Users.Where
                (u => u.Email != null).ToList();

            List<Dbmodel.Blacklist> blacklists = new List<Dbmodel.Blacklist>()
            {
                new Dbmodel.Blacklist
                {
                    User = users.FirstOrDefault(u => u.Email == "peter@gmail.com"),
                    Blacklisted = users.FirstOrDefault(u => u.Email == "ivan@gmail.com"),
                },
                new Dbmodel.Blacklist
                {
                    User = users.FirstOrDefault(u => u.Email == "george@gmail.com"),
                    Blacklisted = users.FirstOrDefault(u => u.Email == "stanimir@gmail.com")
                },
                new Dbmodel.Blacklist
                {
                    User = users.FirstOrDefault(u => u.Email == "stanimir@gmail.com"),
                    Blacklisted = users.FirstOrDefault(u => u.Email == "george@gmail.com")
                }
            };

            context.Blacklist.AddRange(blacklists);
            context.SaveChanges();
        }
    }
}
