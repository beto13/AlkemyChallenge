using Entities;
using IData.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly DataContext dataContext;

        public CharacterRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<Character> GetCharacterById(int id)
        {
            return await dataContext.Characters.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Character>> GetCharacters()
        {
            return await dataContext.Characters.ToListAsync();
        }

        public async Task AddCharacter(Character character)
        {
           dataContext.Characters.Add(character);
           await dataContext.SaveChangesAsync();
        }

        public async Task UpdateCharacter(Character character)
        {
            dataContext.Entry(character).State = EntityState.Modified;
            await dataContext.SaveChangesAsync();
        }

        public async Task DeleteCharacter(Character character)
        {
            dataContext.Remove(character);
            await dataContext.SaveChangesAsync();
        }

        public async Task<bool> Exist(int id)
        {
            return await dataContext.Characters.AnyAsync(x => x.Id == id);
        }
    }
}
