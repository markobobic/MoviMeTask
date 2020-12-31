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
    public class BillService :EntityService<Bill>,IBillService
    {
        private readonly IFilmRepository _filmRepo;
        private readonly IBillRepository _billRepo;
        public BillService(IFilmRepository filmRepo,IBillRepository billRepo):base(billRepo)
        {
            _filmRepo = filmRepo;
            _billRepo = billRepo;
        }

        public async Task<IEnumerable<BillIndexViewModel>> GetAllBillsDataAsync()
        {
            return await _billRepo.GetAllBillsDataAsync();
        }

        public async Task<Bill> GetByIdAsNoTrackingAsync(int id)
        {
            return await _billRepo.GetByIdAsNoTrackingAsync(id);
        }

        public async Task<Bill> GetByIdAsync(int id)
        {
            return await _billRepo.GetByIdAsync(id);
        }

        public async Task<Bill> MapDataAddAsync(BillViewModel viewModel)
        {
            Bill newBill = new Bill();
            var film = await _filmRepo.GetByIdAsync(viewModel.FilmId);
            newBill.Films.Add(film);
            newBill.TimeOfPurchase = DateTime.Now;
            newBill.TotalPrice = viewModel.Quantity * film.Price;
            film.Amount = film.Amount - viewModel.Quantity;
            _filmRepo.Update(film);
            return newBill;
        }


        public Task<Bill> MapDataUpdateAsync(BillUpdateViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}