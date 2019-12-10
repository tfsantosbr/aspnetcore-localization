using LocalizationTest.Domain.Users;
using LocalizationTest.Domain.Users.Models;
using LocalizationTest.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LocalizationTest.Api.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : Controller
    {
        [HttpPost]
        public IActionResult Post(CreateUser createUser)
        {
            var user = new User(
                name: createUser.Name,
                email: createUser.Email,
                address: new Address(
                    streetAddress: createUser.Address.StreetAddress,
                    number: createUser.Address.Number,
                    city: createUser.Address.City
                    )
                );

            foreach (var phone in createUser.Phones)
            {
                user.AddPhone(new Phone(phone.AreaCode, phone.CountryCode, phone.Number));
            }

            var validationsFailures = user.GetValidationErrors();

            if (validationsFailures.Any())
            {
                return BadRequest(validationsFailures);
            }

            var userDetails = new UserDetails
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                Address = new UserAddressDetails
                {
                    StreetAddress = user.Address.StreetAddress,
                    City = user.Address.City,
                    Number = user.Address.Number
                }
            };

            return Created($"htttp://localhost/users/{userDetails.Id}", userDetails);
        }
    }
}
