﻿using System;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly_New.Models {
    public class Rental {

        public Rental(Customer customer, Movie movie) {
            Customer = customer;
            Movie = movie;
            --Movie.Available;
            DateRented = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        public Customer Customer { get; set; }

        [Required]
        public Movie Movie { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }
    }
}