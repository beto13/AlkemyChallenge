using Services.Models.Genre;
using System.Collections.Generic;

namespace Services.Models.Movie
{
    public class MovieDetailsModel
    {
        public List<GenreModel> Genrs { get; set; }
        public List<MovieCharacterModel> Characters { get; set; }
    }
}
