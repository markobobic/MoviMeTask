using MovieMe.Models;
using MovieMe.Repository;
using MovieMe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MovieMe.Services
{
    public class GenreService:EntityService<Genre>,IGenreService
    {
        private readonly IGenreRepository _genreRepo;
        public GenreService(IGenreRepository genreRepo) : base(genreRepo)
        {
            _genreRepo = genreRepo;
        }
        #region GetData
        public async Task<IEnumerable<Genre>> GetAGenresDataAsync()
        {
            return await _genreRepo.GetAGenresDataAsync();
        }

        public async Task<Genre> GetByIdAsNoTrackingAsync(int id)
        {
            return await _genreRepo.GetByIdAsNoTrackingAsync(id);
        }

        public async Task<Genre> GetByIdAsync(int id)
        {
            return await _genreRepo.GetByIdAsync(id);
        }
        #endregion
        #region Mapping 
        public async Task<Genre> MapDataAddAsync(GenreAddViewModel viewModel)
        {
            if (viewModel != null)
            {
                Genre newGenre = new Genre();
                await Task.Run(() =>
                {
                    newGenre.Name = viewModel.Name;
                    newGenre.ShortDescription = viewModel.ShortDescription;
                    
                });
                return newGenre;
            }
            throw new ArgumentException();
        }

        public async Task<Genre> MapDataUpdateAsync(GenreUpdateViewModel viewModel)
        {
            var currentGenre = await GetByIdAsync(viewModel.Id);
            currentGenre.Name = viewModel.Name;
            currentGenre.ShortDescription = viewModel.ShortDescription;
            return currentGenre;
        }
        #endregion
    }
}