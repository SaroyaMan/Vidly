using System;
using System.ComponentModel.DataAnnotations;
using Vidly_New.Models;

namespace Vidly.Models {

    public class Movie {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate {get; set;}

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Number In Stock")]
        [Range(1, 20)]
        public int NumberInStock { get; set; }

        public Genre Genre { get; set; }

        public byte GenreId { get; set; }
    }
}