using System;
using System.Collections.Generic;
using System.Text;
using SMECommerce.Repositories.Abstractions;
using SMECommerce.services.Abstractions;

namespace SMECommerce.services
{
    public abstract class Service<T> : IService<T> where T:class
    {
        IRepository<T> repository;

        public Service(IRepository<T> repository)
        {
            this.repository = repository;
        }
        public virtual bool Add(T entity)
        {
            return repository.Add(entity);
        }

        public virtual ICollection<T> GetAll()
        {
            return repository.GetAll();
        }

        public virtual T GetById(int id)
        {
            return repository.GetById(id);
        }

        public virtual bool Remove(T entity)
        {
            return repository.Remove(entity);
        }

        public virtual bool Update(T entity)
        {
            return repository.Update(entity);
        }
    }
}
