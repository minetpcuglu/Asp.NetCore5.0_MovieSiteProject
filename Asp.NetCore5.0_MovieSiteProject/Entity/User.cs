using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_MovieSiteProject.Entity
{
    public class User
    {
      
            [Key]
            public int userId { get; set; }
            public string UserName { get; set; }
            public string Mail { get; set; }
            public string Password { get; set; }
            public string ImageUrl { get; set; }

            public Person Person { get; set; }  //1-1 tablo 

        
    }
}
