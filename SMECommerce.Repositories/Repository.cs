using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SMECommerce.Repositories.Abstractions;

namespace SMECommerce.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {

        DbContext db;
        public Repository(DbContext db)
        {
            this.db = db;
        }

        private DbSet<T> Table
        {
            get
            {
                return db.Set<T>();
            }
        }
        public virtual bool Add(T entity)
        {
            db.Add(entity);
            return db.SaveChanges() > 0;
        }

        public virtual ICollection<T> GetAll()
        {
            return Table.ToList();
        }

        public abstract T GetById(int id);
         

        public virtual bool Remove(T entity)
        {
            db.Remove(entity);
            return db.SaveChanges() > 0;
        }

        public virtual bool Update(T entity)
        {
            db.Update(entity);
            return db.SaveChanges() > 0;
        }
    }
}
