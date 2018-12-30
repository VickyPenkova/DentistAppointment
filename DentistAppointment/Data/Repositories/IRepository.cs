using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistAppointment.Data
{
    public interface IRepository<T, TKey> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(TKey id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        void Save();
    }
}
