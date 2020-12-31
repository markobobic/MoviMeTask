using log4net;
using MovieMe.Logger;
using MovieMe.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace MovieMe.Repository
{
    public abstract class GenericRepository<T> : IDisposable, IGenericRepository<T> where T : class
    {
        protected ApplicationDbContext RepositoryContext { get; set; }

        public GenericRepository(ApplicationDbContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }
        #region CRUD
        public IQueryable<T> FindAllAsNoTrackingAsync()
        {
            return  this.RepositoryContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByConditionAsNoTracking(Expression<Func<T, bool>> expression)
        {
            try
            {
                return this.RepositoryContext.Set<T>()
                .Where(expression).AsNoTracking();
            }
            catch (Exception e)
            {

                Logger<GenericRepository<T>>.Log.Error($"Error for FindByConditionAsNoTracking:{e.Message} ", e);
                throw;
            }

        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            try
            {
                return this.RepositoryContext.Set<T>()
                .Where(expression);
            }
            catch (Exception e)
            {

                Logger<GenericRepository<T>>.Log.Error($"Error for FindByCondition:{e.Message} ", e);
                 throw;
            }

        }

        public void Create(T entity)
        {
            try
            {
                this.RepositoryContext.Set<T>().Add(entity);
            }
            catch (Exception e)
            {

                Logger<GenericRepository<T>>.Log.Error($"Error for Create:{e.Message} ", e);
                throw;
            }

        }

        public void Update(T entity)
        {
            try
            {
                RepositoryContext.Set<T>().Attach(entity);
                RepositoryContext.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception e)
            {

                Logger<GenericRepository<T>>.Log.Error($"Error for Update:{e.Message} ", e);
                throw;
            }

        }

        public void Delete(T entity)
        {
            try
            {
                RepositoryContext.Entry(entity).State = EntityState.Deleted;
                this.RepositoryContext.Set<T>().Remove(entity);
            }
            catch (Exception e)
            {
                Logger<GenericRepository<T>>.Log.Error($"Error for Delete: {e.Message}", e);
                throw;
            }

        }

        public async Task SaveAsync()
        {
            try
            {
              await RepositoryContext.SaveChangesAsync();

            }
            catch (Exception e)
            {

                Logger<GenericRepository<T>>.Log.Error($"Error for SaveChanges:{e.Message} ", e);
                throw;
            }
        }
        #endregion
        #region Disposable
        private bool _isDisposed;

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (!_isDisposed)
            {
                if (isDisposing)
                {
                    if (this.RepositoryContext != null)
                        this.RepositoryContext.Dispose();
                }

                _isDisposed = true;
            }
        }

        #endregion
    }
}