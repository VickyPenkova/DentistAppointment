using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DentistAppointment.Data.Models;

namespace DentistAppointment.Data
{
    public class DentistAppointmentDbContext : IdentityDbContext
    {
        public DentistAppointmentDbContext(DbContextOptions<DentistAppointmentDbContext> options)
            : base(options)
        {
        }

        public new DbSet<User> Users { get; set; }
        public DbSet<Dentist> Dentists { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Blacklist> Blacklist { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
