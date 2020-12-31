using MovieMe.Models;
using MovieMe.Services;
using MovieMe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MovieMe.Repository
{
  public interface IGenreRepository : IGenericRepository<Genre>
    {
        Task<IEnumerable<Genre>> GetAGenresDataAsync();
        Task<Genre> GetByIdAsync(int id);
        Task<Genre> GetByIdAsNoTrackingAsync(int id);
        
       
    }
}
