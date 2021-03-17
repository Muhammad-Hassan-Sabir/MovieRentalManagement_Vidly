using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearIfAMember:ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId==MembershipType.PayAsYouGo || customer.MembershipTypeId==MembershipType.UnKnown)
            {
                return ValidationResult.Success;
            }

            if (customer.BirthDate==null)
            {
                return new ValidationResult("Birth Date is required");

            }

            var age = DateTime.Now.Year - customer.BirthDate.Value.Year;


            return (age > 18) ? ValidationResult.Success :
                new ValidationResult("Member should be at least 18 years old to go on a membership");
            






        }








    }
}