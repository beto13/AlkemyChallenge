using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using MoviesApi.Models.Characters;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MoviesApi.IServices;
using System.IO;
using System;

namespace MoviesApi.Controllers
{
    [ApiController]
    [Route("api/characters")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService characterService;
        private readonly IFileManager fileManager;
        private readonly string container = "characters";

        public CharacterController(
            ICharacterService characterService,
            IFileManager fileManager)
        {
            this.characterService = characterService;
            this.fileManager = fileManager;
        }

        [HttpGet("{id:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<CharacterModel>> GetCharacterById(int id)
        {
            var characterModel = await characterService.GetCharacterById(id);
            if (characterModel == null)
                return NotFound();

            return characterModel;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IList<CharacterModel>>> GetCharacters()
        {
            return await characterService.GetCharacters();
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> AddCharacter([FromForm]CharacterAddUpdateModel characterAddUpdateModel)
        {
            try
            {
                if (characterAddUpdateModel.File != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        await characterAddUpdateModel.File.CopyToAsync(ms);
                        var content = ms.ToArray();
                        var extension = Path.GetExtension(characterAddUpdateModel.File.FileName);
                        characterAddUpdateModel.Image = await fileManager.AddFile(content, extension, container, characterAddUpdateModel.File.ContentType);
                    }
                }

                await characterService.AddCharacter(characterAddUpdateModel);

                return Ok();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> UpdateCharacter(int id,[FromForm] CharacterAddUpdateModel characterAddUpdateModel)
        {
            try
            {
                if (characterAddUpdateModel.File != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        await characterAddUpdateModel.File.CopyToAsync(ms);
                        var content = ms.ToArray();
                        var extension = Path.GetExtension(characterAddUpdateModel.File.FileName);
                        characterAddUpdateModel.Image = await fileManager.UpdateFile(content, extension, container, characterAddUpdateModel.Image, characterAddUpdateModel.File.ContentType);
                    }
                }

                var updated = await characterService.UpdateCharacter(id, characterAddUpdateModel);

                if (updated)
                    return Ok();
                else
                    return NotFound();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult>DeleteCharacter(int id)
        {
            await characterService.DeleteCharacter(id);

            return NoContent();
        }
    }
}
