using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_MovieSiteProject.Entity
{
    public class Crew //yönetmen
    {
        public int CrewId { get; set; }

        public virtual Movie Movie { get; set; }
        public int MovieId { get; set; }  //çoka çok

        public virtual Person Person { get; set; }
        public int PersonId { get; set; }  //çoka çok


        public string Job { get; set; } 
    }
}
