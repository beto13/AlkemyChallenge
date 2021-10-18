using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using IData.Repositories;
using Entities;

namespace Data.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly DataContext dataContext;

        public GenreRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<Genre> GetGenreById(int id)
        {
            return await dataContext.Genres.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Genre>> GetGenres()
        {
            return await dataContext.Genres.ToListAsync();
        }

        public async Task<bool> Exist(int id)
        {
            return await dataContext.Genres.AnyAsync(x => x.Id == id);
        }

        public async Task AddGenre(Genre genre)
        {
            dataContext.Add(genre);
            await dataContext.SaveChangesAsync();
        }

        public async Task UpdateGenre(Genre Genre)
        {
            dataContext.Entry(Genre).State = EntityState.Modified;
            await dataContext.SaveChangesAsync();
        }

        public async Task DeleteGenre(Genre genre)
        {
            dataContext.Remove(genre);
            await dataContext.SaveChangesAsync();
        }
    }
}
