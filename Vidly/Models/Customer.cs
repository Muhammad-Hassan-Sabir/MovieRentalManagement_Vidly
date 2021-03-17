using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please Enter Customer Name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubcribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Date Of Birth")]
        [Min18YearIfAMember]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "MemberShip Type")]
        public byte MembershipTypeId { get; set; }


        

    }
}