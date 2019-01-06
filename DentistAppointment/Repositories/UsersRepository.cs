using DentistAppointment.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DentistAppointment.Repositories
{
    public class UsersRepository<T, TKey>// : IRepository<T, TKey>
     where T : DentistAppointment.Data.Models.User
    {
        public UsersRepository(DentistAppointmentDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            this.Context = context;
            //this.DbSet = this.Context.Set<T>();
        }

        protected DbSet<T> DbSet { get; set; }

        protected DentistAppointmentDbContext Context { get; set; }

        public async Task<T> GetByIdAsync(TKey id)
        {
            return await this.DbSet.FindAsync(id);
        }

        public T GetById(TKey id)
        {
            return this.DbSet.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return this.DbSet;
        }
      /*  public IQueryable<T> GetAllNotDeletedEntities()
        {
            return this.DbSet.Where(x => x.IsDeleted == false);
        }

        public void Add(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Added);
        }

        public void Update(TKey id, T entity)
        {
            this.ChangeEntityState(entity, EntityState.Modified);
        }*/
    }
}
