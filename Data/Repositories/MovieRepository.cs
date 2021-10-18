using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using IData.Repositories;
using Entities;

namespace Data.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DataContext dataContext;

        public MovieRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<Movie> GetMovieById(int id)
        {
            var movie =  await dataContext.Movies
                .Include(x => x.MovieCharacters).ThenInclude(x => x.Character)
                .Include(x => x.MovieGenres).ThenInclude(x => x.Genre)
                .FirstOrDefaultAsync(x => x.Id == id);

            return movie;
        }

        public async Task<List<Movie>> GetMovies()
        {
            var movies = await dataContext.Movies.ToListAsync();

            return movies;
        }

        public async Task<bool> Exist(int id)
        {
            var exist = await dataContext.Movies.AnyAsync(x => x.Id == id);
            return exist;
        }

        public async Task AddMovie(Movie movie)
        {
            dataContext.Add(movie);
            await dataContext.SaveChangesAsync();
        }

        public async Task UpdateMovie(Movie movie)
        {
            dataContext.Entry(movie).State = EntityState.Modified;
            await dataContext.SaveChangesAsync();
        }

        public async Task DeleteMovie(Movie movie)
        {
            dataContext.Remove(movie);
            await dataContext.SaveChangesAsync();
        }
    }
}
