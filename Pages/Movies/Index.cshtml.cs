using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dotnet.Mvc.Data;
using Dotnet.Mvc.Models;

namespace Dotnet.Mvc.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly Dotnet.Mvc.Data.RazorPagesMovieContext _context;

        public IndexModel(Dotnet.Mvc.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }
    }
}
