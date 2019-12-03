using System;
using System.Collections.Generic;
using System.Text;

namespace LocalizationTest.Domain.Users.Models
{
    public class CreateUser
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public CreateUserAddress Address { get; set; } = new CreateUserAddress();
    }
}
