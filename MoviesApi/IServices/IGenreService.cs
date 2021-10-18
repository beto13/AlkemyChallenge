using System.Collections.Generic;
using System.Threading.Tasks;
using MoviesApi.Models.Genre;

namespace MoviesApi.IServices
{
    public interface IGenreService
    {
        Task<GenreModel> GetGenreById(int id);
        Task<List<GenreModel>> GetGenres();
        Task AddGenre(GenreAddUpdateModel model);
        Task<bool> UpdateGenre(int id, GenreAddUpdateModel model);
        Task<bool> DeleteGenre(int id);
    }
}
