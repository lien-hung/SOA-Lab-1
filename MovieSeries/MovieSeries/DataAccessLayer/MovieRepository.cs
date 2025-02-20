using Microsoft.EntityFrameworkCore;
using MovieSeries.CoreLayer.Entities;

namespace MovieSeries.DataAccessLayer
{
    public class MovieRepository
    {

        private readonly AppDbContext _context;
        public MovieRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await _context.Movies.ToListAsync();
        }
        public async Task AddMovieAsync(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
        }
    }
}
