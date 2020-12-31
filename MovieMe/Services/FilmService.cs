using MovieMe.ExtensionMethods;
using MovieMe.Models;
using MovieMe.Repository;
using MovieMe.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MovieMe.Services
{
    public class FilmService:EntityService<Film>,IFilmService 
    {
       
        private readonly IArtistRepository<Director> _directorRepo;
        private readonly IArtistRepository<Actor> _actorRepo;
        private readonly IArtistRepository<Producer> _producerRepo;
        private readonly IGenreRepository _genreRepo;
        private readonly IFilmRepository _filmRepo;
       
        public FilmService(
             IArtistRepository<Director> directorRepo,IArtistRepository<Actor> actorRepo
            ,IArtistRepository<Producer> producerRepo
            ,IGenreRepository genreRepo, IFilmRepository filmRepo
            
            ) : base(filmRepo)
        {
            _filmRepo = filmRepo;
            _producerRepo = producerRepo;
            _actorRepo = actorRepo;
            _directorRepo = directorRepo;
            _genreRepo = genreRepo;
        }

        #region Dropdowns
        public async Task<IEnumerable<SelectListItem>> IncludeActorsDropdown([Optional] int? actorId)
        {
            var data = await _filmRepo.MakeDropdownForActors(actorId);
            return data;
        }

        public async Task<IEnumerable<SelectListItem>> IncludeDirectorsDropdown([Optional] int? directorId)
        {
            var data = await _filmRepo.MakeDropdownForDirectors(directorId);
            return data;
        }

        public async Task<IEnumerable<SelectListItem>> IncludeProducersDropdown([Optional] int? producerId)
        {
            var data = await _filmRepo.MakeDropdownForProducers(producerId);
            return data;
        }
        public async Task<IEnumerable<SelectListItem>> IncludeGenresDropdown([Optional] int? genreId)
        {
            var data = await _filmRepo.MakeDropdownForGenres(genreId);
            return data;
        }
        #endregion
        #region Mapping
        public async Task<Film> MapDataAddAsync(FilmAddViewModel viewModel)
        {
            var newFilm = new Film();
            newFilm.Genre = await _genreRepo.GetByIdAsync(viewModel.GenreId);
            newFilm.Amount = viewModel.Amount;
            newFilm.DateOfRelese = viewModel.DateOfRelese;
            newFilm.Description = viewModel.Description;
            newFilm.IMDBRating = viewModel.IMDBRating;
            newFilm.Name = viewModel.Name;
            newFilm.Price = viewModel.Price;
            var director = await _directorRepo.GetByIdAsync(viewModel.DirectorId);
            var producer = await _producerRepo.GetByIdAsync(viewModel.ProducerId);
            director.Films.Add(newFilm);
            producer.Films.Add(newFilm);
            var actors = await _actorRepo.GetMultipleArtistsByIds(viewModel.Actors);
            newFilm.Actors.AddRange(actors);
            foreach(var actor in actors)
            {
                actor.Films.Add(newFilm);
            }
            return newFilm;

        }

        public async Task<Film> MapDataUpdateAsync(FilmUpdateViewModel viewModel)
        {
            var currentFilm = await _filmRepo.GetByIdAsync(viewModel.Id);
            currentFilm.Amount = viewModel.Amount;
            currentFilm.DateOfRelese = viewModel.DateOfRelese;
            currentFilm.Description = viewModel.Description;
            currentFilm.IMDBRating = viewModel.IMDBRating;
            currentFilm.Name = viewModel.Name;
            currentFilm.Director = viewModel.DirectorId != currentFilm.Director.Id ? 
                await _directorRepo.GetByIdAsync(viewModel.DirectorId) : currentFilm.Director;
            currentFilm.Producer = viewModel.ProducerId != currentFilm.Producer.Id ?
                await _producerRepo.GetByIdAsync(viewModel.ProducerId) : currentFilm.Producer;
            currentFilm.Genre = viewModel.GenreId != currentFilm.Genre.Id ? 
                await _genreRepo.GetByIdAsync(viewModel.GenreId) : currentFilm.Genre;
            var actors = await _actorRepo.GetMultipleArtistsByIds(viewModel.ActorsSelectedIds);
            currentFilm.Actors.Clear();
             currentFilm.Actors.AddRange(actors);
           
            return currentFilm;
        }
        #endregion
        #region GetData
        public async Task<Film> GetByIdAsync(int id)
        {
           return await _filmRepo.GetByIdAsync(id);
        }

        public async Task<Film> GetByIdAsNoTrackingAsync(int id)
        {
            return await _filmRepo.GetByIdAsNoTrackingAsync(id);
        }

        public Task<IEnumerable<FilmIndexViewModel>> GetAllFilmsDataAsync()
        {
            return _filmRepo.GetAllFilmsDataAsync();
        }
        #endregion

    }
}