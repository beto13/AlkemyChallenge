using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using MoviesApi.Validations;
using MoviesApi.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.AspNetCore.Mvc;

namespace MoviesApi.Models.Movie
{
    public class MovieAddUpdateModel
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Tittle { get; set; }

        public DateTime CreationDate { get; set; }

        [Range(0,5)]
        public int Rating { get; set; }

        public string Image { get; set; }

        [FileSizeValidation(MaxSizeMb: 4)]
        [FileTypeValidation(fileType: FileType.Image)]
        public IFormFile File { get; set; }

        [ModelBinder(BinderType = typeof(TypeBinder<List<int>>))]
        public List<int> GenresId { get; set; }

        [ModelBinder(BinderType = typeof(TypeBinder<List<MovieCharacterModel>>))]
        public List<MovieCharacterModel> Characters { get; set; }
    }
}
