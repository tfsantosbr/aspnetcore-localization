using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocalizationTest.Domain.ValueObjects
{
    public class Phone
    {
        public Phone(string areaCode, string countryCode, string number)
        {
            AreaCode = areaCode;
            CountryCode = countryCode;
            Number = number;
        }

        public string AreaCode { get; private set; }
        public string CountryCode { get; private set; }
        public string Number { get; private set; }

        public IList<ValidationFailure> GetValidationErrors()
        {
            var validation = new PhoneValidator();
            var result = validation.Validate(this);

            return result.Errors;
        }
    }

    public class PhoneValidator : AbstractValidator<Phone>
    {
        public PhoneValidator()
        {
            RuleFor(p => p.AreaCode)
                .NotEmpty()
                .MaximumLength(3)
                .WithName(DomainResources.GetString("Phone Area Code"))
                //.OverridePropertyName("Phone.Street")
                ;

            RuleFor(p => p.Number)
                .NotEmpty()
                .MaximumLength(10)
                .WithName(DomainResources.GetString("Phone Number"))
                //.OverridePropertyName("Phone.Number")
                ;

            RuleFor(p => p.CountryCode)
                .NotEmpty()
                .MaximumLength(3)
                .WithName(DomainResources.GetString("Phone Country Code"))
                //.OverridePropertyName("Phone.City")
                ;
        }
    }
}
