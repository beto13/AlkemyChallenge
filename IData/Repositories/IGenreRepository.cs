using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace IData.Repositories
{
    public interface IGenreRepository
    {
        Task<Genre> GetGenreById(int id);
        Task<bool> Exist(int id);
        Task<List<Genre>> GetGenres();
        Task AddGenre(Genre Genre);
        Task UpdateGenre(Genre Genre);
        Task DeleteGenre(Genre Genre);
    }
}
