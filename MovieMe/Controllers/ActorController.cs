using MovieMe.Models;
using MovieMe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MovieMe.Controllers
{
    public class ActorController : Controller
    {
        private readonly IArtistRepository<Actor> db;

        public ActorController(IArtistRepository<Actor> _db)
        {
            db = _db;

        }
        public  ActionResult Index()
        {
            
            return View();

        }
    }
}