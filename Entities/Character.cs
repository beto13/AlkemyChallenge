using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Character
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        [StringLength(300)]
        public string History { get; set; }

        [StringLength(300)]
        public string Image { get; set; }

        public List<MovieCharacter> MovieCharacters { get; set; }
    }
}
