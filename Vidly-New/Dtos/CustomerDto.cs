using System;
using System.ComponentModel.DataAnnotations;

// DTO = Data Transfer Object

namespace Vidly_New.Dtos {
    public class CustomerDto {

        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        //[Min18YearsIfMember]
        public DateTime? Birthdate { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        public byte MembershipTypeId { get; set; }
    }
}