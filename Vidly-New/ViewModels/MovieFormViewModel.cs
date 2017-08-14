using System.Collections.Generic;
using Vidly.Models;
using Vidly_New.Models;

namespace Vidly_New.ViewModels {
    public class MovieFormViewModel {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
    }
}