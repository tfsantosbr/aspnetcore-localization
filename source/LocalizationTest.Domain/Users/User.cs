using FluentValidation;
using FluentValidation.Results;
using LocalizationTest.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace LocalizationTest.Domain.Users
{
    public class User
    {
        private readonly List<Phone> _phones = new List<Phone>();

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
        public IReadOnlyList<Phone> Phones => _phones.AsReadOnly();

        public IList<ValidationFailure> GetValidationErrors()
        {
            var validation = new UserValidator();
            var userValidationResult = validation.Validate(this);

            return userValidationResult.Errors;
        }

        public void AddPhone(Phone phone)
        {
            //if (phone.GetValidationErrors() != null)
            //{
            //    _validationFailures.AddRange(phone.GetValidationErrors());
            //    return;
            //}

            _phones.Add(phone);
        }
    }

    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .MaximumLength(100)
                .WithName(DomainResources.GetString("Name"))
                ;

            RuleFor(p => p.Email)
                .NotEmpty()
                .MaximumLength(100)
                .WithName(DomainResources.GetString("E-mail Address"))
                ;

            RuleFor(p => p.Address).SetValidator(new AddressValidator());

            RuleFor(p => p.Phones).Must(phones => phones.Count > 0)
                .WithMessage(DomainResources.GetString("Must have at least one phone"));

            RuleForEach(p => p.Phones).SetValidator(new PhoneValidator());
        }
    }
}
