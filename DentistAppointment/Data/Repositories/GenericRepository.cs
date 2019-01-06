using DentistAppointment.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistAppointment.Data
{
    public class GenericRepository<T, TKey> :
        IRepository<T, TKey> where T : class
    {
        public GenericRepository(DentistAppointmentDbContext context)
        {
            this.Context = context;
            this.Db = this.Context.Set<T>();
        }

        public DentistAppointmentDbContext Context { get; set; }

        public DbSet<T> Db { get; set; }

        public virtual IQueryable<T> GetAll()
        {
            return Db;
        }

        public virtual T GetById(TKey id)
        {
            return Db.Find(id);
        }
        
        public virtual void Add(T entity)
        {
            Db.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            Db.Remove(entity);
        }

        public virtual void Update(T entity)
        {
            Db.Update(entity);
        }
        public virtual void Update(Guid id, User user)
        {
            Db.Update(entity);
        }

        public virtual void Save()
        {
            Context.SaveChanges();
        }
    }
}
