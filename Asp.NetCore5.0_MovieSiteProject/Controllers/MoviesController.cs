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

        public IActionResult List()
        {
           

            var model = new MoviesViewModel()
            {
                Movies = MovieRepository.Movies
               
            };

            return View("Movies",model);
        }


        public IActionResult Details()
        {
            return View();
        }

     
    }
}
