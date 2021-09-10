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
                  new Genre{Name="Dram" },
                 new Genre{Name="Gerilim"},
                 new Genre{Name="Bilim Kurgu"},
                 new Genre{Name="Gizem"},
                 new Genre{Name="Komedi"},
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
