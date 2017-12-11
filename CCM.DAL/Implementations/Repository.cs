using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;

namespace CCM.DAL
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private CCMContext dataContext;
        private readonly DbSet<T> dbSet;

        protected Repository(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;

            dbSet = DataContext.Set<T>();
        }

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        protected CCMContext DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        }
        public virtual void Add(T entity)
        {
            dbSet.Add(entity);

        }
        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            dataContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }
        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbSet.Remove(obj);
        }
        public virtual T GetByID(long ID)
        {
            return dbSet.Find(ID);
        }
        public virtual T GetByID(string ID)
        {
            return dbSet.Find(ID);
        }
        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).ToList();
        }
        public T Get(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).FirstOrDefault<T>();
        }
        public virtual IEnumerable<T> GetWithRawSQL(string query, params object[] parameters)
        {
            return dbSet.SqlQuery(query, parameters).ToList();
        }
    }
}
