using System.Collections.Generic;
using Vidly.Models;

namespace Vidly_New.Models {
    public class RentalDto {

        //public int Id { get; set; }

        public int CustomerId { get; set; }
        public List<int> MovieIds { get; set; }
    }
}