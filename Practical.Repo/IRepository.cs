﻿using Practical.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical.Repo
{
   public interface IRepository<T> where T : class
    {
        IQueryable<T> Table();
        IEnumerable<T> GetAll();
        
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
    }
}
