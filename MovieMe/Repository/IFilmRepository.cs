using MovieMe.Models;
using MovieMe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MovieMe.Repository
{
    public interface IFilmRepository : IGenericRepository<Film>,IDropdownForFilm
    {
        Task<Film> GetByIdAsync(int id);
        Task<Film> GetByIdAsNoTrackingAsync(int id);
        Task<IEnumerable<FilmIndexViewModel>> GetAllFilmsDataAsync();
        
    }
}