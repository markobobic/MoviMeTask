using MovieMe.Models;
using MovieMe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MovieMe.Services
{
    public interface IGenreService : IEntityService<Genre>, 
        IMapData<Genre, GenreAddViewModel, GenreUpdateViewModel>
    {
        Task<IEnumerable<Genre>> GetAGenresDataAsync();
        Task<Genre> GetByIdAsync(int id);
        Task<Genre> GetByIdAsNoTrackingAsync(int id);
    }
}