using MovieMe.Models;
using MovieMe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MovieMe.Repository
{
    public interface IBillRepository : IGenericRepository<Bill>
    {
        Task<Bill> GetByIdAsync(int id);
        Task<Bill> GetByIdAsNoTrackingAsync(int id);
        Task<IEnumerable<BillIndexViewModel>> GetAllBillsDataAsync();
    }
}