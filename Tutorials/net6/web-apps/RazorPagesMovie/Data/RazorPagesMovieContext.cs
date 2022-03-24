using Microsoft.EntityFrameworkCore;

namespace RazorPagesMovie.Data
{
    public class RazorPagesMovieContext : DbContext
    {
#pragma warning disable CS8618
        public RazorPagesMovieContext(DbContextOptions<RazorPagesMovieContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesMovie.Models.Movie> Movie { get; set; }
    }
}
