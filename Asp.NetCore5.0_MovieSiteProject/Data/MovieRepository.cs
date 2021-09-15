using Asp.NetCore5._0_MovieSiteProject.Entity;
using Asp.NetCore5._0_MovieSiteProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_MovieSiteProject.Data
{
    public class MovieRepository
    {
        private static readonly List<Movie> _movies = null;

        static MovieRepository()
        {
            _movies = new List<Movie>()
            {
                new Movie{ MovieId=1,GenreId=2, Title="11.22.63" , Description="11.22.63, Stephen King'in 22/11/63 kitabından esinlenmiş, sekiz bölümden oluşan Amerikalı bilimkurgu ve gerilim televizyon mini dizisidir. Dizi, J. J. Abrams, Bridget Carpenter ve Bryan Burk tarafından yönetici olarak üretilmiş ilk olarak 15 Şubat 2016'da Hulu üzerinden yayınlanmıştır." , Director="MT", ImageUrl="11.22.63.jpg" },
                new Movie{MovieId=2,GenreId=3,Title="Behind Her Eyes" , Description="Behind Her Eyes, 17 Şubat 2021'de Netflix'te prömiyeri yapılan ve Sarah Pinborough tarafından aynı adlı 2017 romanından uyarlanan Steve Lightfoot tarafından yaratılan İngiliz kara kara doğaüstü psikolojik gerilim web dizisi. Hewson ve Robert Aramayo. " , Director="Sarah Pinborough",ImageUrl="behindhereyes.jpg" },
                new Movie{MovieId=3,GenreId=4,Title="La Case De Papel" , Description="Álex Pina tarafından yaratılan İspanya yapımı bir soygun ve suç dizisi. Dizi, profosör liderliğindeki ekibin İspanya Kraliyet Darphanesi'ni ve İspanya Merkez Bankası'nı soymasını konu edinir." , Director="Álex Pina",ImageUrl="indir.jfif" },
                new Movie{MovieId=4,GenreId=3,Title="Interstellar" , Description="Elif Türker" , Director="ET", ImageUrl="film4.jfif" },
                new Movie{MovieId=5,GenreId=2,Title="Esaretin Bedeli" , Description="Eray Türker" , Director="ET",ImageUrl="esaret.jfif" },
                new Movie{MovieId=6,GenreId=1, Title="Yeşil Yol" , Description="Ali Osman Topcuoglu" , Director="AOT", ImageUrl="yesilyol.jfif" }
            };
        }

        public static List<Movie> Movies
        {
            get
            {
                return _movies;
            }
        }

        public static void Add(Movie movie)
        {
            movie.MovieId = _movies.Count() + 1;
            _movies.Add(movie);
        }

        public static void Delete(int MovieId)
        {
            var movie = GetById(MovieId);
            if (movie!=null)
            {
                _movies.Remove(movie);
            }
        }
        public static void Update(Movie movie)
        {
            foreach (var item in _movies)
            {
                if (item.MovieId==movie.MovieId)
                {
                    item.Title = movie.Title;
                    item.Description = movie.Description;
                    item.Director = movie.Director;
                    item.ImageUrl = movie.ImageUrl;
                    item.GenreId = movie.GenreId;
                    break;

                }
            }
        }

        public static Movie GetById(int id)
        {
            return _movies.FirstOrDefault(x => x.MovieId ==id);
        }
    }
}
