using Asp.NetCore5._0_MovieSiteProject.Data;
using Asp.NetCore5._0_MovieSiteProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_MovieSiteProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new HomePageViewModel()
            {
                PopulerMovies = MovieRepository.Movies
            };
            return View(model);
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
