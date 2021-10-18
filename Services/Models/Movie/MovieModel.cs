using System;
using System.ComponentModel.DataAnnotations;

namespace Services.Models.Movie
{
    public class MovieModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Tittle { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        public int Rating { get; set; }

        public string Image { get; set; }
    }
}
