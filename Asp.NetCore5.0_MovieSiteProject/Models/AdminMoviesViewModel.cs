using Asp.NetCore5._0_MovieSiteProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_MovieSiteProject.Models
{
    public class AdminMoviesViewModel
    {
        public List<Movie> Movies { get; set; }
    }

    public class AdminMovieViewModel
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<Genre> Genres { get; set; }
    }
    public class AdminEditViewModel
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Description{ get; set; }
        public string ImageUrl { get; set; }
        public List<Genre> SelectedGenres { get; set; }
    }
}
