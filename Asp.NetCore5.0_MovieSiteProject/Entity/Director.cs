using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_MovieSiteProject.Entity
{
    public class Director
    {

        [Key]
        public int DirectorId { get; set; }

      
        public string Name { get; set; }


        public string ImageUrl { get; set; }
        public string Biography { get; set; }
    }
}
