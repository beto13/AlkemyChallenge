using System.Collections.Generic;
using MoviesApi.Models.Characters;
using MoviesApi.Models.Genre;
using MoviesApi.Models.Movie;
using AutoMapper;
using Entities;

namespace MoviesApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Character, CharacterModel>().ReverseMap();
            CreateMap<CharacterAddUpdateModel, Character>().ReverseMap()
                .ForMember(x => x.File, options => options.Ignore());

            CreateMap<Movie, MovieModel>().ReverseMap();
            CreateMap<Movie, MovieDetailsModel>()
                .ForMember(x => x.Genrs, options => options.MapFrom(MapMoviesGenres))
                .ForMember(x => x.Characters, options => options.MapFrom(MapMoviesCharacters));

            CreateMap<MovieAddUpdateModel, Movie>()
                .ForMember(x => x.Image, options => options.Ignore())
                .ForMember(x => x.MovieGenres, options => options.MapFrom(MapMoviesGenres))
                .ForMember(x => x.MovieCharacters, options => options.MapFrom(MapMoviesCharacters));

            CreateMap<Genre, GenreModel>().ReverseMap();
            CreateMap<GenreAddUpdateModel, Genre>().ReverseMap();
        }

        private List<GenreModel> MapMoviesGenres(Movie movie, MovieDetailsModel movieDetailsModel)
        {
            var result = new List<GenreModel>();

            if (movie.MovieGenres == null) { return result; }

            foreach (var movieGenres in movie.MovieGenres)
            {
                result.Add(new GenreModel()
                {
                    Id = movieGenres.GenreId,
                    Name = movieGenres.Genre.Name
                });
            }

            return result;
        }

        private List<MovieGenre> MapMoviesGenres(MovieAddUpdateModel movieAddUpdateModel, Movie movie)
        {
            var result = new List<MovieGenre>();

            if (movieAddUpdateModel.GenresId == null) { return result; }

            foreach (var Id in movieAddUpdateModel.GenresId)
                result.Add(new MovieGenre() { GenreId = Id });

            return result;
        }
       
        
        private List<MovieCharacterModel> MapMoviesCharacters(Movie movie, MovieDetailsModel movieDetailsModel)
        {
            var result = new List<MovieCharacterModel>();

            if (movie.MovieCharacters == null) { return result; }

            foreach (var movieCharacter in movie.MovieCharacters)
            {
                result.Add(new MovieCharacterModel
                {
                    CharacterId = movieCharacter.CharacterId,
                    Character = movieCharacter.Character.Name
                });
            }

            return result;
        }

        private List<MovieCharacter> MapMoviesCharacters(MovieAddUpdateModel MovieAddUpdateModel, Movie movie)
        {
            var result = new List<MovieCharacter>();

            if (MovieAddUpdateModel.Characters == null) { return result; }

            foreach (var Character in MovieAddUpdateModel.Characters)
            {
                result.Add(new MovieCharacter
                {
                    CharacterId = Character.CharacterId
                });
            }

            return result;
        }
    }
}
