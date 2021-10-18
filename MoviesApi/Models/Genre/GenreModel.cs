using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Models.Genre
{
    public class GenreModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
