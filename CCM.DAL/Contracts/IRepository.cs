using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CCM.DAL
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        T GetByID(long ID);
        T GetByID(string ID);
        T Get(Expression<Func<T, bool>> where);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        IEnumerable<T> GetWithRawSQL(string query, params object[] parameters);
    }
}
