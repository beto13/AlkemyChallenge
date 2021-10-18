using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IData.Repositories
{
    public interface IMovieRepository
    {
        Task<Movie> GetMovieById(int id);
        Task<bool> Exist(int id);
        Task<List<Movie>> GetMovies();
        Task AddMovie(Movie movie);
        Task UpdateMovie(Movie movie);
        Task DeleteMovie(Movie movie);
    }
}
