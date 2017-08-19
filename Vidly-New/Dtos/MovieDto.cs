using System;
using System.ComponentModel.DataAnnotations;
using Vidly_New.Models;

namespace Vidly_New.Dtos {
    public class MovieDto {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        [Range(1, 20)]
        public int NumberInStock { get; set; }

        public byte GenreId { get; set; }
    }
}