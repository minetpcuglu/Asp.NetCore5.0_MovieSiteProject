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
                new Movie{ MovieId=1, Title="film 1" , Description="Mine Topcuoglu" , Director="MT", Players=new string[] { "oyuncu 1 ", "oyuncu 2"},ImageUrl="11.22.63.jpg" },
                new Movie{MovieId=2,Title="film 2" , Description="Emre Topcuoglu" , Director="ET", Players=new string[] { "oyuncu 1 ", "oyuncu 2"},ImageUrl="behindhereyes.jpg" },
                new Movie{MovieId=3,Title="film 3" , Description="Gönül Topcuoglu" , Director="GT", Players=new string[] { "oyuncu 1 ", "oyuncu 2"},ImageUrl="La-Casa-de-Papel.web.jpg" },
                  new Movie{MovieId=4,Title="film 4" , Description="Elif Topcuoglu" , Director="ET", Players=new string[] { "oyuncu 1 ", "oyuncu 2"},ImageUrl="11.22.63.jpg" },
                new Movie{MovieId=5,Title="film 5" , Description="Eray Topcuoglu" , Director="ET", Players=new string[] { "oyuncu 1 ", "oyuncu 2"},ImageUrl="behindhereyes.jpg" },
                new Movie{MovieId=6,Title="film 6" , Description="Ali Osman Topcuoglu" , Director="AOT", Players=new string[] { "oyuncu 1 ", "oyuncu 2"},ImageUrl="La-Casa-de-Papel.web.jpg" }
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
            _movies.Add(movie);
        }

        public static Movie GetById(int id)
        {
            return _movies.FirstOrDefault(x => x.MovieId ==id);
        }
    }
}
