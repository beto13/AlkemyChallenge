using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MoviesApi.Models.Genre;
using MoviesApi.IServices;
using System;

namespace MoviesApi.Controllers
{
    [ApiController]
    [Route("api/genres")]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService genreService;

        public GenreController(IGenreService genreService)
        {
            this.genreService = genreService;
        }

        [HttpGet("{id:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<GenreModel>> GetgenreById(int id)
        {
            var genreModel = await genreService.GetGenreById(id);
            if (genreModel == null)
                return NotFound();

            return genreModel;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IList<GenreModel>>> Getgenres()
        {
            return await genreService.GetGenres();
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Addgenre([FromBody] GenreAddUpdateModel genreAddUpdateModel)
        {
            try
            {
                await genreService.AddGenre(genreAddUpdateModel);

                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Updategenre(int id, [FromBody] GenreAddUpdateModel genreAddUpdateModel)
        {
            try
            {
                var updated = await genreService.UpdateGenre(id, genreAddUpdateModel);

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
        public async Task<ActionResult> Deletegenre(int id)
        {
            await genreService.DeleteGenre(id);

            return NoContent();
        }
    }
}
