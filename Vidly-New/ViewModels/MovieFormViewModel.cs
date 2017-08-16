using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;
using Vidly_New.Models;

namespace Vidly_New.ViewModels {
    public class MovieFormViewModel {
        public IEnumerable<Genre> Genres { get; set; }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }


        [Display(Name = "Number In Stock")]
        [Range(1, 20)]
        public int NumberInStock { get; set; }

        public byte GenreId { get; set; }



        public string Title {
            get {
                return Id == 0 ? "New Movie" : "Edit Movie";
            }
        }

        public MovieFormViewModel(Movie movie) {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }

        public MovieFormViewModel() {
            Id = 0;
        }
    }
}