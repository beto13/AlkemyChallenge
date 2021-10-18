using System.ComponentModel.DataAnnotations;
using System;

namespace MoviesApi.Models.Movie
{
    public class MovieModel
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
    }
}
