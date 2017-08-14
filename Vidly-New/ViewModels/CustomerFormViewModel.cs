using System;
using System.Collections.Generic;
using Vidly.Models;
using Vidly_New.Models;

namespace Vidly_New.ViewModels {
    public class CustomerFormViewModel {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}