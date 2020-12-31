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
    public class BillController : Controller
    {
        private readonly IBillService db;
        public BillController(IBillService _db)
        {
            db = _db;
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> GenerateBill(BillViewModel data)
        {
            if (ModelState.IsValid)
            {
                var newBill = await db.MapDataAddAsync(data);
                db.Create(newBill);
                await db.SaveAsync();
                return View("../Bill/Index");
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        }
        [HttpGet]
        public async Task<ActionResult> GetData()
        {
            var billData = await db.GetAllBillsDataAsync();
            return Json(billData, JsonRequestBehavior.AllowGet);

        }
    }
}