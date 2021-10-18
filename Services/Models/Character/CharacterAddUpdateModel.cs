using Microsoft.AspNetCore.Http;
using Services.Helpers;
using Services.Validations;
using System;
using System.ComponentModel.DataAnnotations;

namespace Services.Models.Characters
{
    public class CharacterAddUpdateModel
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        [StringLength(300)]
        public string History { get; set; }

        public string Image { get; set; }

        [FileSizeValidation(MaxSizeMb: 4)]
        [FileTypeValidation(fileType: FileType.Image)]
        public IFormFile File { get; set; }
    }
}
