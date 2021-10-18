using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace Entities
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Tittle { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Range(0, 5)]
        public int Rating { get; set; }

        [StringLength(300)]
        public string Image { get; set; }

        public List<MovieCharacter> MovieCharacters { get; set; }
        public List<MovieGenre> MovieGenres { get; set; }
    }
}
