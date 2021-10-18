using MoviesApi.Models.Movie;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesApi.IServices
{
    public interface IMovieService
    {
        Task<MovieDetailsModel> GetMovieById(int id);
        Task<List<MovieModel>> GetMovies();
        Task AddMovie(MovieAddUpdateModel model);
        Task<bool> UpdateMovie(int id, MovieAddUpdateModel model);
        Task<bool> DeleteMovie(int id);
    }
}
