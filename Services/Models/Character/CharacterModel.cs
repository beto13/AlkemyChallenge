using System;
using System.ComponentModel.DataAnnotations;

namespace Services.Models.Characters
{
    public class CharacterModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string Image { get; set; }

        [StringLength(300)]
        public string History { get; set; }
    }
}
