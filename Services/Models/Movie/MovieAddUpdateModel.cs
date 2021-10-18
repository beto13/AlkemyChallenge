using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Services.Validations;
using Services.Helpers;
using System;
using System.Collections.Generic;
using Services.Models.Characters;
using Services.Models.Genre;
using Services.Models.Character;

namespace Services.Models.Movie
{
    public class MovieAddUpdateModel
    {
        public int Id { get; set; }


        [StringLength(100)]
        public string Tittle { get; set; }


        public DateTime CreationDate { get; set; }

        public int Rating { get; set; }

        public string Image { get; set; }

        [FileSizeValidation(MaxSizeMb: 4)]
        [FileTypeValidation(fileType: FileType.Image)]
        public IFormFile File { get; set; }

        public int[] Characters { get; set; }
        public List<GenreModel> Genres { get; set; }
    }
}
