using System.Collections.Generic;
using System.Threading.Tasks;
using MoviesApi.Models.Movie;
using MoviesApi.IServices;
using IData.Repositories;
using System.Linq;
using AutoMapper;
using Entities;
using System;

namespace MoviesApi.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository movieRepository;
        private readonly IMapper mapper;

        public MovieService(
            IMovieRepository movieRepository,
            IMapper mapper)
        {
            this.movieRepository = movieRepository;
            this.mapper = mapper;
        }

        public async Task<MovieDetailsModel> GetMovieById(int id)
        {
            try
            {
                var movie = await movieRepository.GetMovieById(id);
                if (movie == null)
                    return null;

                return mapper.Map<MovieDetailsModel>(movie);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<MovieModel>> GetMovies()
        {
            try
            {
                var movies = await movieRepository.GetMovies();
                if (!movies.Any())
                    return null;

                return mapper.Map<List<MovieModel>>(movies);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task AddMovie(MovieAddUpdateModel model)
        {
            try
            {
                var movie = mapper.Map<Movie>(model);
                await movieRepository.AddMovie(movie);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateMovie(int id, MovieAddUpdateModel model)
        {
            try
            {
                var exists = await movieRepository.Exist(id);
                if (!exists)
                    return false;

                var movie = mapper.Map<Movie>(model);
                movie.Id = id;

                await movieRepository.UpdateMovie(movie);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteMovie(int id)
        {
            try
            {
                var movie = await movieRepository.GetMovieById(id);
                if (movie == null)
                    return false;

                await movieRepository.DeleteMovie(movie);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
