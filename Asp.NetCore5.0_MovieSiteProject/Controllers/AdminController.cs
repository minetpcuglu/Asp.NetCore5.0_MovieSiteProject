using Asp.NetCore5._0_MovieSiteProject.Data;
using Asp.NetCore5._0_MovieSiteProject.Entity;
using Asp.NetCore5._0_MovieSiteProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_MovieSiteProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly Context _context;

        public AdminController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MovieList()
        {

            return View(new AdminMoviesViewModel
            {
                Movies = _context.Movies.Include(m => m.Genres).ToList()

            });
        }
        [HttpGet]
        public IActionResult MovieUpdate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _context.Movies.Select(m => new AdminEditViewModel
            {

                MovieId = m.MovieId,
                Title = m.Title,
                Description = m.Description,
                ImageUrl = m.ImageUrl
                ,
                SelectedGenres = m.Genres
            }).FirstOrDefault(m => m.MovieId == id);


            //ütr bilgileri tasıma
            ViewBag.genres = _context.Genres.ToList();

            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> MovieUpdate(AdminMovieViewModel model, int[] genreIds, IFormFile file) //resim ekleme file işlemi
        {
            var entity = _context.Movies.Include(m => m.Genres).FirstOrDefault(m => m.MovieId == model.MovieId);
            if (entity == null)
            {
                return NotFound();
            }
            entity.Title = model.Title;
            entity.Description = model.Description;


            if (file != null) //resim gönderme işlemi
            {
                var extension = Path.GetExtension(file.FileName); //.jpg ... resim uzantısı gelir 
                var fileName = string.Format($"{Guid.NewGuid()}{extension}");  //wwwroot olan img isimleriyle aynı olursa diye random bi isim belirleme
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", fileName);//proje yolunu root kaydetme işlemi
                entity.ImageUrl = fileName;

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }


            entity.Genres = genreIds.Select(id => _context.Genres.FirstOrDefault(i => i.GenreId == id)).ToList(); //oluşturulan liste her id ye gelen genre nesnesine karsılık gelmelı
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }

        public IActionResult GenreList()
        {
            return View(new AdminGenresViewModel
            {
                Genres = _context.Genres.Select(t => new AdminGenreViewModel
                {
                    GenreId = t.GenreId,
                    Name = t.Name,
                    Count = t.Movies.Count()

                }).ToList()

            });
        }

        [HttpGet]
        public IActionResult GenreUpdate(int? id) //türe ait film bilgileri guncelleme 
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = _context.Genres.Select(m => new AdminGenreEditViewModel
            {
                GenreId = m.GenreId,
                Name = m.Name,
                Movies = m.Movies.Select(i => new AdminMovieViewModel
                {
                    MovieId = i.MovieId,
                    Title = i.Title,
                    ImageUrl = i.ImageUrl

                }).ToList()
            }).FirstOrDefault(m => m.GenreId == id);

            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }


        [HttpPost]
        public IActionResult GenreUpdate(AdminGenreEditViewModel model, int[] movieIds)
        {
            var entity = _context.Genres.Include("Movies").FirstOrDefault(m => m.GenreId == model.GenreId);
            if (entity == null)
            {
                return NotFound();
            }
            entity.Name = model.Name;
            foreach (var id in movieIds)
            {
                entity.Movies.Remove(entity.Movies.FirstOrDefault(m => m.MovieId == id));
            }

            _context.SaveChanges();
            return RedirectToAction("GenreList");
        }

        [HttpGet]
        public IActionResult GenreDelete()
        {
            return View();

        }

        [HttpPost]
        public IActionResult GenreDelete(int genreId)
        {
            var value = _context.Genres.Find(genreId);
            if (value != null)
            {
                _context.Genres.Remove(value);
                _context.SaveChanges();
            }
            return RedirectToAction("GenreList");
        }

        [HttpGet]
        public IActionResult MovieDelete()
        {
            return View();

        }

        [HttpPost]
        public IActionResult MovieDelete(int movieId)
        {
            var value = _context.Movies.Find(movieId);
            if (value != null)
            {
                _context.Movies.Remove(value);
                _context.SaveChanges();
            }
            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Genres = _context.Genres.ToList();
            return View(new  AdminCreateValidationViewModel());
        }



        [HttpPost]
        public IActionResult AddMovie(AdminCreateValidationViewModel t)
        {
            if (t.Title!=null && t.Title.Contains("@"))
            {
                ModelState.AddModelError("", "Film başlığı @ işareti içeremez");
            }



            //if (t.GenreIds==null) // validation rules en az bir tür seçimi. //sonradna required cevirdik
            //{
            //    ModelState.AddModelError("GenreIds", "En az bir tür bilgisi şeçmelisiniz");
            //}




            if (ModelState.IsValid)
            {
                var entity = new Movie
                {
                    Title = t.Title,
                    Description = t.Description,
                    ImageUrl = "Null"
                };

        
            foreach (var genre in t.GenreIds)
            {
                entity.Genres.Add(_context.Genres.FirstOrDefault(x => x.GenreId == genre));
            }
            _context.Movies.Add(entity);
            _context.SaveChanges();
            return RedirectToAction("MovieList", "Admin");
        }
             ViewBag.Genres = _context.Genres.ToList();
            return View(t); //sayfa yenilediginde aynı bilgilerin gelmesi için
    }




}
}
