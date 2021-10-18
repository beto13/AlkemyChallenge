using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using IData.Repositories;
using AutoMapper;
using MoviesApi.Models.Genre;
using System.Linq;
using Entities;
using MoviesApi.IServices;

namespace Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository genreRepository;
        private readonly IMapper mapper;

        public GenreService(
            IGenreRepository genreRepository,
            IMapper mapper)
        {
            this.genreRepository = genreRepository;
            this.mapper = mapper;
        }

        public async Task<GenreModel> GetGenreById(int id)
        {
            try
            {
                var genre = await genreRepository.GetGenreById(id);
                if (genre == null)
                    return null;

                return mapper.Map<GenreModel>(genre);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<GenreModel>> GetGenres()
        {
            try
            {
                var genres = await genreRepository.GetGenres();
                if (!genres.Any())
                    return null;

                return mapper.Map<List<GenreModel>>(genres);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateGenre(int id, GenreAddUpdateModel model)
        {
            try
            {
                var exists = await genreRepository.Exist(id);
                if (!exists)
                    return false;

                var genre = mapper.Map<Genre>(model);
                genre.Id = id;

                await genreRepository.UpdateGenre(genre);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task AddGenre(GenreAddUpdateModel model)
        {
            try
            {
                var genre = mapper.Map<Genre>(model);
                await genreRepository.AddGenre(genre);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteGenre(int id)
        {
            try
            {
                var genre = await genreRepository.GetGenreById(id);
                if (genre == null)
                    return false;

                await genreRepository.DeleteGenre(genre);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
