using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace int_core_test_2.Interfaces
{
  public  interface Igeneric<T>where T:class
    {
        List<T> GetAll();
        T GetById(int id);
        void Create(T obj);
        void Edit(T obj);
        void Delete(T obj);
        void Save();
    }
}
