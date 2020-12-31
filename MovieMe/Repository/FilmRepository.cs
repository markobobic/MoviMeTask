using MovieMe.ExtensionMethods;
using MovieMe.Logger;
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
    public class FilmRepository : GenericRepository<Film>,IFilmRepository,IDisposable
    {
        private readonly ApplicationDbContext db;
        public FilmRepository(ApplicationDbContext _db) : base(_db)
        {
            db = _db;
        }
        #region CRUD

        public async Task<IEnumerable<FilmIndexViewModel>> GetAllFilmsDataAsync()
        {
            var all = await FindAllAsNoTrackingAsync().ToListAsync();
            try
            {
                var data = all.Select(film => new FilmIndexViewModel
                {
                    Id = film.Id,
                    DateOfRelese = film.DateOfRelese,
                    Description = film.Description,
                    DirectorName = film.Director.Name,
                    IMDBRating = film.IMDBRating,
                    Actors = film.Actors.Select(x=> x.Name ).ToArray(),
                    Amount = film.Amount,
                    GenreName = film.Genre.Name,
                    Name = film.Name,
                    Price = film.Price,
                    ProducerName = film.Producer.Name
                }).ToList();
                return data;
            }
            catch (Exception e)
            {
                Logger<FilmRepository>.Log.Error(e.Message);
                throw;
            }
        }

        public async Task<Film> GetByIdAsNoTrackingAsync(int id)
        {
            return await FindByConditionAsNoTracking(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Film> GetByIdAsync(int id)
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
        #region MakeDropdowns
        public async Task<IEnumerable<SelectListItem>> MakeDropdownForDirectors([Optional] int? directorId)
        {
            return await db.Directors.ToDropdown(directorId);
        }

        public async Task<IEnumerable<SelectListItem>> MakeDropdownForProducers([Optional] int? producerId)
        {
            return await db.Producers.ToDropdown(producerId);
        }

        public async Task<IEnumerable<SelectListItem>> MakeDropdownForActors([Optional] int? actorId)
        {
            return await db.Actors.ToDropdown(actorId);
        }

        public async Task<IEnumerable<SelectListItem>> MakeDropdownForGenres([Optional] int? genreId)
        {
            return await db.Genres.ToDropdown(genreId);
        }
        #endregion
    }
}