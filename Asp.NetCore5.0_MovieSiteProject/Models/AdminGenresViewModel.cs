using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_MovieSiteProject.Models
{
    public class AdminGenresViewModel
    {
        [Required(ErrorMessage ="Tür Bilgisi Boş Bırakılamaz")]
        public string Name { get; set; }
        public List<AdminGenreViewModel> Genres { get; set; }
    }

    public class AdminGenreViewModel
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
    }

    public class AdminGenreEditViewModel
    {
        public int GenreId { get; set; }
        [Required(ErrorMessage = "Tür Bilgisi Boş Bırakılamaz")]
        public string Name { get; set; }
        public List<AdminMovieViewModel> Movies { get; set; }
    }

}
