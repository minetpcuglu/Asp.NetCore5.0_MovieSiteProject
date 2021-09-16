using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_MovieSiteProject.Entity
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Required]
        public string Title { get; set; }

        
        public string Description { get; set; }
        //public string Director { get; set; }
        public string ImageUrl { get; set; }

        /*İlişkiler*/
        public List<Genre> Genres { get; set; }  //çpoka çok  //tablo otamatik oluscak 
    }
}
