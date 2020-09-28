using Microsoft.EntityFrameworkCore;

namespace Dotnet.Mvc.Data
{
  public class RazorPagesMovieContext : DbContext
  {
    public RazorPagesMovieContext (
      DbContextOptions<RazorPagesMovieContext> options)
      : base(options)
    {
    }

    public DbSet<Dotnet.Mvc.Models.Movie> Movie { get; set; }
  }
}
