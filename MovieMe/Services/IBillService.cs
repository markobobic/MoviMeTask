using MovieMe.Models;
using MovieMe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MovieMe.Services
{
    public interface IBillService : IMapData<Bill, BillViewModel, BillUpdateViewModel>,IEntityService<Bill>
    {
        Task<Bill> GetByIdAsync(int id);
        Task<Bill> GetByIdAsNoTrackingAsync(int id);
        Task<IEnumerable<BillIndexViewModel>> GetAllBillsDataAsync();
    }
}