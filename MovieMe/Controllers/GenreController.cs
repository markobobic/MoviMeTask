using MovieMe.Models;
using MovieMe.Repository;
using MovieMe.Services;
using MovieMe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MovieMe.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreService db;
        public GenreController(IGenreService _db)
        {
            db = _db;
           
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(GenreAddViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var newGenre =await db.MapDataAddAsync(viewModel);
                db.Create(newGenre);
                await db.SaveAsync();
                return Json(new { success = true, message = "Added Successfully" });

            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        }
        [HttpGet]
        public async Task<ActionResult> GetData()
        {
            var genreData = await db.GetAGenresDataAsync();
            return Json(genreData, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            if (id > 0)
            {
                var genre = await db.GetByIdAsNoTrackingAsync(id);
                if (genre == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.NotFound);

                }
                var viewModel = new GenreUpdateViewModel(genre);
                return View(viewModel);
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(GenreUpdateViewModel viewModel)
        {
            if (ModelState.IsValid) { 
            var genreUpdated = await db.MapDataUpdateAsync(viewModel);
            db.Update(genreUpdated);
            await db.SaveAsync();
            return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);

            }
            return new HttpStatusCodeResult(HttpStatusCode.NotModified);

        }
        [HttpPost]
        public async Task<ActionResult>Delete(int id)
        {
            var genreToDelete =await db.GetByIdAsync(id);
            if(genreToDelete != null) { 
            db.Delete(genreToDelete);
            await db.SaveAsync();
            return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);

        }

    }
}