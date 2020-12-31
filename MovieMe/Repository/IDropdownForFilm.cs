using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MovieMe.Repository
{
    public interface IDropdownForFilm
    {
        Task<IEnumerable<SelectListItem>> MakeDropdownForDirectors([Optional] int? directorId);
        Task<IEnumerable<SelectListItem>> MakeDropdownForProducers([Optional] int? producerId);
        Task<IEnumerable<SelectListItem>> MakeDropdownForActors([Optional] int? actorId);
        Task<IEnumerable<SelectListItem>> MakeDropdownForGenres([Optional] int? genreId);

    }
}