using System.Collections;
using System.Collections.Generic;

namespace LocalizationTest.Domain.Users.Models
{
    public class CreateUser
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public CreateUserAddress Address { get; set; } = new CreateUserAddress();

        public IEnumerable<CreateUserPhone> Phones { get; set; } = new List<CreateUserPhone>();
    }
}
