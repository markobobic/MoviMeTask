using MovieMe.Models;
using MovieMe.Services;
using MovieMe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MovieMe.Repository
{
    public interface IArtistRepository<T> :IGenericRepository<T> where T : Artist
    {
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsNoTrackingAsync(int id);
        IQueryable<T> GetAllAsync();
        Task<List<T>> GetMultipleArtistsByIds(int[] ids);
    }
}