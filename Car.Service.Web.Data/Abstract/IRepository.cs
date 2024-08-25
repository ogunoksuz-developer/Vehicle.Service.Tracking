﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Car.Service.Web.Data.Abstract
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveChangesAsync();
        IQueryable<T> SearchAsync(Expression<Func<T, bool>> predicate);

        Task<IEnumerable<T>> ExecuteStoredProcedureAsync(string storedProcedure, params object[] parameters);
    }

}
