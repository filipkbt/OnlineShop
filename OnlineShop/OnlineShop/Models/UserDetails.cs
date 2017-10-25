using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class UserDetails
    {
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }
        [RegularExpression(@"(\+\d{2})*[\d\s-]+", ErrorMessage = "Wrong phone number")]
        public string Phone { get; set; }

        [EmailAddress(ErrorMessage="Wrong e-mail")]
        public string Email { get; set; }
    }
}