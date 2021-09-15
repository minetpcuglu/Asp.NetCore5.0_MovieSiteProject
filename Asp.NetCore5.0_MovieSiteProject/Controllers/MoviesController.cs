using Asp.NetCore5._0_MovieSiteProject.Data;
using Asp.NetCore5._0_MovieSiteProject.Entity;
using Asp.NetCore5._0_MovieSiteProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_MovieSiteProject.Controllers
{
    public class MoviesController : Controller
    {
        private readonly Context _context;

        public MoviesController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {


            return View();
        }

        //var controller = RouteData.Values["controller"];
        //var action = RouteData.Values["action"];
        //var genreid = RouteData.Values["id"];
        public IActionResult List(int? id, string q)
        {

            var kelime = HttpContext.Request.Query["q"].ToString();  //var kelime = q ile aynı  //arama butonu ayarlama get motodu ile 

            var movies = _context.Movies.AsQueryable();
            if (id != null)
            {
                movies = movies.Where(m => m.GenreId == id);
            }
            if (!string.IsNullOrEmpty(q))
            {
                movies = movies.Where(t =>
                t.Title.ToLower().Contains(q.ToLower()) ||
                t.Description.ToLower().Contains(q.ToLower()));
            }

            var model = new MoviesViewModel()
            {
                Movies = movies.ToList()

            };

            return View("Movies", model);
        }


        public IActionResult Details(int id)
        {
            return View(_context.Movies.Find(id));
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.genres = new SelectList(_context.Genres.ToList(), "GenreId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Movie m)
        {
            if (ModelState.IsValid)
            {
                //MovieRepository.Add(m);

                _context.Add(m);
                _context.SaveChanges();

                TempData["alertmessage"] = $"{m.Title} isimli film eklendi";
                return RedirectToAction("List");




            }
            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.genres = new SelectList(_context.Genres.ToList(), "GenreId", "Name");
            return View(_context.Movies.Find(id));
        }

        [HttpPost]
        public IActionResult Update(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Update(movie);
                _context.SaveChanges();

                return RedirectToAction("Details", "Movies", new { @id = movie.MovieId });
            }
            ViewBag.genres = new SelectList(_context.Genres.ToList(), "GenreId", "Name");
            return View(movie);
        }


        [HttpPost]
        public IActionResult Delete(int MovieId, string title)
        {
            var entity = _context.Movies.Find(MovieId);
            _context.Movies.Remove(entity);
            _context.SaveChanges();
            TempData["alertmessage"] = $"{title} isimli film silindi";
            return RedirectToAction("List");


        }

    }
}

