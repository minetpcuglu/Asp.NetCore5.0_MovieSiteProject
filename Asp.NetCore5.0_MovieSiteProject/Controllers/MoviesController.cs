using Asp.NetCore5._0_MovieSiteProject.Data;
using Asp.NetCore5._0_MovieSiteProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_MovieSiteProject.Controllers
{
    public class MoviesController : Controller
    {
        //public IActionResult Index(int id)
        //{
        //    string filmbasliği = "Film Başlığı";
        //    string filmaciklama = "Film Açıklama";
        //    string filmyonetmen = "Film Yönetmen Adı";
        //    string[] oyuncular = { "oyuncu 1" , "oyuncu 2"};

        //    ViewBag.filmbasligi = filmbasliği;
        //    ViewBag.filmaciklama = filmaciklama;
        //    ViewBag.filmyonetmen = filmyonetmen;
        //    ViewBag.oyuncu = oyuncular;
        //    return View();
        //}

        public IActionResult Index()
        {
            string filmbasliği = "Film Başlığı";
            string filmaciklama = "Film Açıklama";
            string filmyonetmen = "Film Yönetmen Adı";
            string[] oyuncular = { "oyuncu 1", "oyuncu 2" };


            var deger = new Movie();

            deger.Title = filmbasliği;
            deger.Description = filmaciklama;
            deger.Director = filmyonetmen;
            deger.Players = oyuncular;
            deger.ImageUrl = "11.22.63.jpg";

            return View(deger);
        }

        public IActionResult List(int? id , string q)
        {
            //var controller = RouteData.Values["controller"];
            //var action = RouteData.Values["action"];
            //var genreid = RouteData.Values["id"];
            var kelime = HttpContext.Request.Query["q"].ToString();  //var kelime = q ile aynı  //arama butonu ayarlama get motodu ile 

            var movies = MovieRepository.Movies;
            if (id != null)
            {
                movies = movies.Where(m => m.GenreId == id).ToList();
            }
            if (!string.IsNullOrEmpty(q))
            {
                movies = movies.Where(t =>
                t.Title.ToLower().Contains(q.ToLower()) ||
                t.Description.ToLower().Contains(q.ToLower())).ToList();
            }

            var model = new MoviesViewModel()
            {
                Movies = movies

            };

            return View("Movies", model);
        }


        public IActionResult Details(int id)
        {
            return View(MovieRepository.GetById(id));
        }


    }
}
