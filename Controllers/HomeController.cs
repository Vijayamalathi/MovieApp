using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieApp.Models;
//comment
namespace MovieApp.Controllers
{
    //comment one
    public class HomeController : Controller
    {
        private MoviesDBEntities _db = new MoviesDBEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View(_db.Movies1.ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude="Id")] Movies movieToCreate)
        {
            if(!ModelState.IsValid)
            
                return View();
            _db.Movies1.Add(movieToCreate);
            _db.SaveChanges();

            return RedirectToAction("index");
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            var moviesToEdit = (from m in _db.Movies1
                                where m.Id == id
                                select m).First();
            return View(moviesToEdit);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(Movies moviesToEdit)
        {
            var originalMovie = (from m in _db.Movies1
                                 where m.Id == moviesToEdit.Id
                                 select m).First();
            if (!ModelState.IsValid)
                return View(originalMovie);
            _db.Entry(originalMovie).CurrentValues.SetValues(moviesToEdit);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

      
    }
}
