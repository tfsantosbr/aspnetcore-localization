using System;
using System.Collections.Generic;
using System.Text;

namespace LocalizationTest.Domain.Users.Models
{
    public class UserDetails
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public UserAddressDetails Address { get; set; }
    }
}
