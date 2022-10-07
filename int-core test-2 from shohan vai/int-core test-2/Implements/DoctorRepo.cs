using int_core_test_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using int_core_test_2.Models;
using Microsoft.EntityFrameworkCore;

namespace int_core_test_2.Implements
{
    public class DoctorRepo<T> : Igeneric<T> where T : class
    {
        private readonly PatientDbcontext db;
        private readonly DbSet<T> table;
        public DoctorRepo(PatientDbcontext db)
        {
            this.db = db;
            this.table = db.Set<T>();
        }
        public void Create(T obj)
        {
            table.Add(obj);
        }

        public void Delete(T obj)
        {
            table.Remove(obj);
        }

        public void Edit(T obj)
        {
            table.Update(obj);
        }

        public List<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(int id)
        {
           return table.Find(id);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
