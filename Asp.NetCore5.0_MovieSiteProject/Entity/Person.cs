using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_MovieSiteProject.Entity
{


    public class Person
    {

        [Key]
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Imbd { get; set; }
        public string HomePage { get; set; }
        public string PlaceOfBirth { get; set; }
        public string ImageUrl { get; set; }
        public string Biography { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; } //null
    }
}
