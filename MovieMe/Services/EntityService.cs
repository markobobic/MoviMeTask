using MovieMe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace MovieMe.Services
{
    public abstract class EntityService<T> : IEntityService<T> where T : class
    {
        IGenericRepository<T> _repository;

        public EntityService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public void Create(T entity)
        {
            _repository.Create(entity);
        }

        public void Delete(T entity)
        {
            _repository.Delete(entity);
        }

        public IQueryable<T> FindAllAsNoTrackingAsync()
        {
           return  _repository.FindAllAsNoTrackingAsync();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _repository.FindByCondition(expression);
        }

        public IQueryable<T> FindByConditionAsNoTracking(Expression<Func<T, bool>> expression)
        {
           return _repository.FindByConditionAsNoTracking(expression);
        }

        public async Task SaveAsync()
        {
            await _repository.SaveAsync();
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
        }
    }
}