using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Models.Genre
{
    public class GenreAddUpdateModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
