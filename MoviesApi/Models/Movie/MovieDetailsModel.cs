using MoviesApi.Models.Genre;
using System.Collections.Generic;

namespace MoviesApi.Models.Movie
{
    public class MovieDetailsModel: MovieModel
    {
        public List<GenreModel> Genrs { get; set; }
        public List<MovieCharacterModel> Characters { get; set; }
    }
}
