using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace IData.Repositories
{
    public interface ICharacterRepository
    {
        Task<Character> GetCharacterById(int id);
        Task<bool> Exist(int id);
        Task<List<Character>> GetCharacters();
        Task AddCharacter(Character character);
        Task UpdateCharacter(Character character);
        Task DeleteCharacter(Character character);
    }
}

