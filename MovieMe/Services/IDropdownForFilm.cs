using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MovieMe.Services
{
    public interface IDropdownForFilmService
    {
        Task<IEnumerable<SelectListItem>> IncludeActorsDropdown([Optional] int? actorId);
        Task<IEnumerable<SelectListItem>> IncludeDirectorsDropdown([Optional] int? directorId);
        Task<IEnumerable<SelectListItem>> IncludeProducersDropdown([Optional] int? producerId);
        Task<IEnumerable<SelectListItem>> IncludeGenresDropdown([Optional] int? genreId);
    }
}