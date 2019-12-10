using System;
using System.Collections.Generic;
using System.Text;

namespace LocalizationTest.Domain.Users.Models
{
    public class CreateUserPhone
    {
        public string AreaCode { get; set; }
        public string CountryCode { get; set; }
        public string Number { get; set; }
    }
}
