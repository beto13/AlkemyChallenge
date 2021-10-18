using System.ComponentModel.DataAnnotations;

namespace Services.Models.Genre
{
    public class GenreModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
