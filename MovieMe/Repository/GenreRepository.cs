using MovieMe.ExtensionMethods;
using MovieMe.Models;
using MovieMe.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MovieMe.Repository
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository,IDisposable
    {
        private readonly ApplicationDbContext db;
        public GenreRepository(ApplicationDbContext _db) : base(_db)
        {
            db = _db;
        }
        #region GetData
        public async Task<IEnumerable<Genre>> GetAGenresDataAsync()
        {
            var data = await FindAllAsNoTrackingAsync().ToListAsync();
            return data.OrderBy(x => x.Name);
        }

        public async Task<Genre> GetByIdAsNoTrackingAsync(int id)
        {
            return await FindByConditionAsNoTracking(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Genre> GetByIdAsync(int id)
        {
            return await FindByCondition(x => x.Id == id).FirstOrDefaultAsync();
        }

        #endregion
        #region Disposable
        private bool _isDisposed;

        protected override void Dispose(bool isDisposing)
        {
            if (!_isDisposed)
            {
                if (isDisposing)
                {
                    if (this.db != null)
                        this.db.Dispose();
                }

                _isDisposed = true;
            }

            base.Dispose(isDisposing);
        }
        #endregion

    }

}