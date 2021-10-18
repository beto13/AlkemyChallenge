using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MoviesApi.Models.Movie;
using MoviesApi.IServices;
using System.IO;
using System;

namespace MoviesApi.Controllers
{
    [ApiController]
    [Route("api/Movies")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService movieService;
        private readonly IFileManager fileManager;
        private readonly string container = "movies";

        public MovieController(
            IMovieService movieService,
            IFileManager fileManager)
        {
            this.movieService = movieService;
            this.fileManager = fileManager;
        }

        [HttpGet("{id:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<MovieDetailsModel>> GetMovieById(int id)
        {
            var MovieModel = await movieService.GetMovieById(id);
            if (MovieModel == null)
                return NotFound();

            return MovieModel;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IList<MovieModel>>> GetMovies()
        {
            return await movieService.GetMovies();
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> AddMovie([FromForm] MovieAddUpdateModel MovieAddUpdateModel)
        {
            try
            {
                if (MovieAddUpdateModel.File != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        await MovieAddUpdateModel.File.CopyToAsync(ms);
                        var content = ms.ToArray();
                        var extension = Path.GetExtension(MovieAddUpdateModel.File.FileName);
                        MovieAddUpdateModel.Image = await fileManager.AddFile(content, extension, container, MovieAddUpdateModel.File.ContentType);
                    }
                }

                await movieService.AddMovie(MovieAddUpdateModel);

                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> UpdateMovie(int id, [FromForm] MovieAddUpdateModel MovieAddUpdateModel)
        {
            try
            {
                if (MovieAddUpdateModel.File != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        await MovieAddUpdateModel.File.CopyToAsync(ms);
                        var content = ms.ToArray();
                        var extension = Path.GetExtension(MovieAddUpdateModel.File.FileName);
                        MovieAddUpdateModel.Image = await fileManager.UpdateFile(content, extension, container, MovieAddUpdateModel.Image, MovieAddUpdateModel.File.ContentType);
                    }
                }

                var updated = await movieService.UpdateMovie(id, MovieAddUpdateModel);

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
        public async Task<ActionResult> DeleteMovie(int id)
        {
            await movieService.DeleteMovie(id);

            return NoContent();
        }
    }
}
