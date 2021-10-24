using Asp.NetCore5._0_MovieSiteProject.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<Genre> SelectedGenres { get; set; }

      
    }


    public class AdminCreateValidationViewModel //validation rules için oluşturuldu
    {
       [Display(Name ="Film Adı")]
       [Required(ErrorMessage ="Film adı boş geçilemez")]
       [StringLength(50, MinimumLength =3 ,ErrorMessage ="Film adı 3 ile 50 karakter arasında olmalıdır. ")]
        public string Title { get; set; }

        [Display(Name = "Film Açıklama")]
        [Required(ErrorMessage = "Film açıklama boş geçilemez")]
        [StringLength(3000, MinimumLength = 10, ErrorMessage = "Açıklama 10 ile 3000 karakter arasında olmalıdır. ")]
        public string Description { get; set; }

  

        [Required(ErrorMessage = "En az bir tür şeçmelisiniz")]
        public int[] GenreIds { get; set; } // validation rules en az bir tür seçimi.
    }

}
