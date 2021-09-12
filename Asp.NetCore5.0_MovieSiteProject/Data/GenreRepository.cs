using Asp.NetCore5._0_MovieSiteProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_MovieSiteProject.Data
{
    public class GenreRepository
    {
        private static readonly List<Genre> _genres = null;

        static GenreRepository()
        {
            _genres = new List<Genre>()
            {
                 new Genre{ GenreId=1, Name="Dram" },
                 new Genre{GenreId=2,Name="Gerilim"},
                 new Genre{GenreId=3,Name="Bilim Kurgu"},
                 new Genre{GenreId=4,Name="Gizem"},
                 new Genre{GenreId=5, Name="Komedi"},
            };
        }

        public static List<Genre> Genres
        {
            get
            {
                return _genres;
            }
        }

        public static void Add(Genre genre)
        {
            _genres.Add(genre);
        }

        public static Genre GetById(int id)
        {
            return _genres.FirstOrDefault(x => x.GenreId == id);
        }
    }
}
