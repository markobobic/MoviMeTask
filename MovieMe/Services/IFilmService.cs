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
    public interface IFilmService :IDropdownForFilmService,
        IMapData<Film,FilmAddViewModel,FilmUpdateViewModel>,IEntityService<Film>
    {
        Task<Film> GetByIdAsync(int id);
        Task<Film> GetByIdAsNoTrackingAsync(int id);
        Task<IEnumerable<FilmIndexViewModel>> GetAllFilmsDataAsync();
    }
}