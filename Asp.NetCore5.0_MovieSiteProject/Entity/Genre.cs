using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_MovieSiteProject.Entity
{
    public class Genre
    {

        [Key]
        public int GenreId { get; set; }
        [Required]
        public string Name { get; set; }

        public List<Movie> Movies { get; set; } //çoka çok tablo

       

    }
}
