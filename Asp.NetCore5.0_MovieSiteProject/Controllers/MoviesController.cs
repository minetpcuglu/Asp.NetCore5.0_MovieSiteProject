using Asp.NetCore5._0_MovieSiteProject.Data;
using Asp.NetCore5._0_MovieSiteProject.Entity;
using Asp.NetCore5._0_MovieSiteProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
                //listeyi alma işlemini include metoduyla yapılır.
                // her gelen filmin listesi bak ve eşleseni al listeye geri gönder
                movies = movies.Include(m => m.Genres).Where(m => m.Genres.Any(g=>g.GenreId==id));  
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

    }
}

