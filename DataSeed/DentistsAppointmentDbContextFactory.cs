using DentistAppointment.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataSeed
{
    class DentistsAppointmentDbContextFactory : IDesignTimeDbContextFactory<DentistAppointmentDbContext>
    {
        public DentistAppointmentDbContext CreateDbContext()
        {
            return this.CreateDbContext(null);
        }

        public DentistAppointmentDbContext CreateDbContext(string[] args)
        {
            var configBuilder = new ConfigurationBuilder();
            configBuilder.AddJsonFile("appsettings.json", optional: false);

            var configuration = configBuilder.Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var builder = new DbContextOptionsBuilder<DentistAppointmentDbContext>();
            builder.UseSqlServer(connectionString);

            return new DentistAppointmentDbContext(builder.Options);
        }
    }
}
