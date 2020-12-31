using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MovieMe.Services
{
    public interface IMapData<T, TAddViewModel, TEditViewModel>
    {
        Task<T> MapDataAddAsync(TAddViewModel viewModel);
        Task<T> MapDataUpdateAsync(TEditViewModel viewModel);
    }
}