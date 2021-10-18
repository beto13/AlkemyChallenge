using AutoMapper;
using Entities;
using IData.Repositories;
using MoviesApi.IServices;
using MoviesApi.Models.Characters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesApi.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository characterRepository;
        private readonly IMapper mapper;

        public CharacterService(
            ICharacterRepository characterRepository, 
            IMapper mapper)
        {
            this.characterRepository = characterRepository;
            this.mapper = mapper;
        }

        public async Task<CharacterModel> GetCharacterById(int id)
        {
            try
            {
                var character = await characterRepository.GetCharacterById(id);
                if (character == null)
                    return null;

                return mapper.Map<CharacterModel>(character);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<CharacterModel>> GetCharacters()
        {
            try
            {
                var characters = await characterRepository.GetCharacters();

                return mapper.Map<List<CharacterModel>>(characters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task AddCharacter(CharacterAddUpdateModel model)
        {
            try
            {
                var character = mapper.Map<Character>(model);
                await characterRepository.AddCharacter(character);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateCharacter(int id, CharacterAddUpdateModel model)
        {
            try
            {
                var exists = await characterRepository.Exist(id);

                if (!exists)
                    return false;

                var character = mapper.Map<Character>(model);
                character.Id = id;

                await characterRepository.UpdateCharacter(character);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteCharacter(int id)
        {
            try
            {
                var character = await characterRepository.GetCharacterById(id);

                if (character == null)
                    return false;

                await characterRepository.DeleteCharacter(character);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
