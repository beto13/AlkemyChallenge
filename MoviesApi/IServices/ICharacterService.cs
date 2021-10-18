using MoviesApi.Models.Characters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesApi.IServices
{
    public interface ICharacterService
    {
        Task<CharacterModel> GetCharacterById(int id);
        Task<List<CharacterModel>> GetCharacters();
        Task AddCharacter(CharacterAddUpdateModel model);
        Task<bool> UpdateCharacter(int id, CharacterAddUpdateModel model);
        Task<bool> DeleteCharacter(int id);
    }
}
