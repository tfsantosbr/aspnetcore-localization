using FluentValidation;
using FluentValidation.Results;
using LocalizationTest.Domain.Helpers;
using System.Collections.Generic;

namespace LocalizationTest.Domain.ValueObjects
{
    public class Address
    {
        public Address(string streetAddress, string number, string city)
        {
            StreetAddress = streetAddress;
            Number = number;
            City = city;
        }

        public string StreetAddress { get; private set; }
        public string Number { get; private set; }
        public string City { get; private set; }

        public IList<ValidationFailure> GetValidationErrors()
        {
            var validation = new AddressValidator();
            var result = validation.Validate(this);

            return result.Errors;
        }
    }

    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(p => p.StreetAddress)
                .NotEmpty()
                .MaximumLength(100)
                .WithName(ResourceLocalizer.GetString("Street Address"))
                ;

            RuleFor(p => p.Number)
                .NotEmpty()
                .MaximumLength(10)
                .WithName(ResourceLocalizer.GetString("Address Number"))
                ;

            RuleFor(p => p.City)
                .NotEmpty()
                .MaximumLength(50)
                .WithName(ResourceLocalizer.GetString("Address City"))
                ;
        }
    }
}
