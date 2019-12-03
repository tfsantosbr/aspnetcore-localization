using FluentValidation;
using FluentValidation.Results;
using LocalizationTest.Domain.Helpers;
using LocalizationTest.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace LocalizationTest.Domain.Users
{
    public class User
    {
        public User(string name, string email, Address address)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Address = address;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public Address Address { get; private set; }

        public IList<ValidationFailure> GetValidationErrors()
        {
            var validationFailures = new List<ValidationFailure>();
            
            var validation = new UserValidator();
            var userValidationResult = validation.Validate(this);

            validationFailures.AddRange(userValidationResult.Errors);
            validationFailures.AddRange(Address.GetValidationErrors());

            return validationFailures;
        }
    }

    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .MaximumLength(100)
                .WithName(ResourceLocalizer.GetString("Name"))
                ;

            RuleFor(p => p.Email)
                .NotEmpty()
                .MaximumLength(100)
                .WithName(ResourceLocalizer.GetString("E-mail Address"))
                ;
        }
    }
}
