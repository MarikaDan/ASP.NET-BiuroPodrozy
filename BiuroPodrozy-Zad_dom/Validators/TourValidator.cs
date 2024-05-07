using FluentValidation;
using BiuroPodrozy_Zad_dom.ViewModels;

namespace Trips.DAL.Validators
{
    public class TripValidator : AbstractValidator<TourViewModel>
    {
        public TripValidator()
        {
            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("Country is required.")
                .MaximumLength(50).WithMessage("Country cannot be longer than 50 characters.");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City is required.")
                .MaximumLength(50).WithMessage("City cannot be longer than 50 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(200).WithMessage("Description cannot be longer than 200 characters.");

            RuleFor(x => x.NumberOfDays)
                .GreaterThan(0).WithMessage("NumberofDays must be greater than 0.");

        }
    }
}