using Asp.NetCore5._0_MovieSiteProject.Data;
using Asp.NetCore5._0_MovieSiteProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_MovieSiteProject.ViewComponents
{
    public class GenresViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
           

            return View(GenreRepository.Genres);
        }
    }
}
