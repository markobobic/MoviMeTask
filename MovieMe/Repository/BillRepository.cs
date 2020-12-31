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
    public class BillRepository : GenericRepository<Bill>,IBillRepository,IDisposable
    {
        private readonly ApplicationDbContext db;
        public BillRepository(ApplicationDbContext _db) : base(_db)
        {
            db = _db;
        }
        #region GetData
        public async Task<IEnumerable<BillIndexViewModel>> GetAllBillsDataAsync()
        {
            var all = await FindAllAsNoTrackingAsync().Include(x=>x.Films).ToListAsync();
            
            var data = all.Select(x => new BillIndexViewModel
            {
                FilmName = x.Films.Select(y => y.Name).FirstOrDefault(),
                Id = x.Id,
                TimeOfPurchase = x.TimeOfPurchase,
                TotalPrice = x.TotalPrice
            }).ToList();
            return data;
        }

        public async Task<Bill> GetByIdAsNoTrackingAsync(int id)
        {
            return await FindByConditionAsNoTracking(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Bill> GetByIdAsync(int id)
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