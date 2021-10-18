﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using MoviesApi.Helpers;
using System.Linq;
using System;

namespace MoviesApi.Validations
{
    public class FileTypeValidation : ValidationAttribute
    {
        private readonly string[] validTypes;

        public FileTypeValidation(string[] validTypes)
        {
            this.validTypes = validTypes;
        }

        public FileTypeValidation(FileType fileType)
        {
            if (fileType == FileType.Image)
            {
                validTypes = new string[] { "image/jpeg", "image/png", "image/gif " };
            }
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            IFormFile formFile = value as IFormFile;

            if (formFile == null)
                return ValidationResult.Success;

            if (!validTypes.Contains(formFile.ContentType))
                return new ValidationResult($"El tipo de archivo es invalido. Archivos permitidos: {string.Join(", ", validTypes)}");

            return ValidationResult.Success;
        }
    }
}
