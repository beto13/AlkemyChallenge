using AutoMapper;
using Entities;
using Services.Models.Character;
using Services.Models.Characters;
using Services.Models.Genre;
using Services.Models.Movie;
using System.Collections.Generic;

namespace Services.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Character, CharacterModel>().ReverseMap();
            CreateMap<CharacterAddUpdateModel, Character>().ReverseMap()
                .ForMember(x => x.File, options => options.Ignore());

            CreateMap<Movie, MovieDetailsModel>()
                .ForMember(x => x.Genrs, options => options.MapFrom(MapMoviesGenres))
                .ForMember(x => x.Characters, options => options.MapFrom(MapMoviesCharacters));

            CreateMap<MovieAddUpdateModel, Movie>()
                .ForMember(x => x.Image, options => options.Ignore())
                .ForMember(x => x.MovieGenres, options => options.MapFrom(MapMoviesGenres))
                .ForMember(x => x.MovieCharacters, options => options.MapFrom(MapMoviesCharacters));
        }

        private List<MovieCharacter> MapMoviesCharacters(MovieAddUpdateModel MovieAddUpdateModel, Movie movie)
        {
            var result = new List<MovieCharacter>();

            if (MovieAddUpdateModel.Characters == null) { return result; }

            foreach (var character in MovieAddUpdateModel.Characters)
            {
                result.Add(new MovieCharacter
                {
                    CharacterId = character
                });
            }

            return result;
        }

        private List<CharacterMovieDetailsModel> MapMoviesCharacters(Movie movie, MovieDetailsModel movieDetailsModel)
        {
            var result = new List<CharacterMovieDetailsModel>();
            if (movie.MovieCharacters == null) { return result; }
            foreach (var movieCharacter in movie.MovieCharacters)
            {
                result.Add(new CharacterMovieDetailsModel
                {
                    CharacterId = movieCharacter.CharacterId,
                    Character = movieCharacter.Character.Name
                });
            }

            return result;
        }

        private List<MovieGenre> MapMoviesGenres(MovieAddUpdateModel movieAddUpdateModel, Movie movie)
        {
            var result = new List<MovieGenre>();
            if (movieAddUpdateModel.Genres == null) { return result; }
            foreach (var genres in movieAddUpdateModel.Genres)
            {
                result.Add(new MovieGenre() { GenreId = genres.Id });
            }

            return result;
        }

        private List<GenreModel> MapMoviesGenres(Movie movie, MovieDetailsModel movieDetailsModel)
        {
            var result = new List<GenreModel>();
            if (movie.MovieGenres == null) { return result; }
            foreach (var movieGenres in movie.MovieGenres)
            {
                result.Add(new GenreModel() { Id = movieGenres.GenreId, Name = movieGenres.Genre.Name });
            }

            return result;
        }

    }
}
