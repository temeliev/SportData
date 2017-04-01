using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace SportData.Web.Interfaces
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbSet<T> set;

        public Repository(DbSet<T> set)
        {
            this.set = set;
        }

        public IEnumerable<T> Entities
        {
            get { return this.set; }
        }

        public void Add(T entity)
        {
            this.set.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            this.set.AddRange(entities);
        }

        public T FirstOrDefault()
        {
            return this.set.FirstOrDefault();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> expression)
        {
            return this.set.FirstOrDefault(expression);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return this.set.Where(expression);
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            return this.set.Any(expression);
        }

        public bool Contains(T entity)
        {
            return this.set.Contains(entity);
        }

        public T Find(int id)
        {
            return this.set.Find(id);
        }

        public int Count()
        {
            return this.set.Count();
        }

        public int Count(Expression<Func<T, bool>> expression)
        {
            return this.set.Count(expression);
        }

        public void Remove(T entity)
        {
            this.set.Remove(entity);
        }

        public void Remove(int id)
        {
            this.set.Remove(this.set?.Find(id));
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            this.set.RemoveRange(entities);
        }
    }
}