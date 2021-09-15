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
        private readonly Context _context;

        public GenresViewComponent(Context context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.selectedGenre = RouteData.Values["id"];

            return View(_context.Genres.ToList()) ;
        }
    }
}
