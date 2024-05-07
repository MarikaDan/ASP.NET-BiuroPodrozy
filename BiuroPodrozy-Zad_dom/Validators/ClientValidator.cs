using FluentValidation;
using BiuroPodrozy_Zad_dom.ViewModels;

namespace Trips.DAL.Validators
{
    public class CustomerValidator : AbstractValidator<ClientViewModel>
    {

        public CustomerValidator()
        {

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(25)
                .Matches("^[a-zA-Z'-]+$").WithMessage("First name can only contain letters, apostrophes, and hyphens.");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(25)
                .Matches("^[a-zA-Z'-]+$").WithMessage("Last name can only contain letters, apostrophes, and hyphens.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.PhoneNumber)
               .NotEmpty();
        }

    }
}