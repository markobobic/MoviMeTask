using log4net;
using MovieMe.Logger;
using MovieMe.Models;
using MovieMe.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MovieMe.Repository
{
    public class ArtistRepository<T> : GenericRepository<T>, IArtistRepository<T>, IDisposable where T : Artist 
    {
        private readonly ApplicationDbContext db;
        public ArtistRepository(ApplicationDbContext _db) : base(_db)
        {
            db = _db;
        }
        #region GetData
        public IQueryable<T> GetAllAsync()
        {

            var allArtist = FindAllAsNoTrackingAsync();
            Logger<ArtistRepository<T>>.Log.Info($"getting all artist {allArtist}");
            return allArtist.OrderBy(x => x.Name);
        }


        public async Task<T> GetByIdAsNoTrackingAsync(int id)
        {
            return await FindByConditionAsNoTracking(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await FindByCondition(x => x.Id == id).FirstOrDefaultAsync();
        }
        public Task<List<T>> GetMultipleArtistsByIds(int[] ids)
        {
            return FindByCondition(x => ids.Contains(x.Id)).Include(x => x.Films).ToListAsync();
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