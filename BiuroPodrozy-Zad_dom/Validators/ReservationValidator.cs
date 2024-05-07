using FluentValidation;
using BiuroPodrozy_Zad_dom.ViewModels;

namespace Trips.DAL.Validators
{
    public class ReservationValidator : AbstractValidator<ReservationViewModel>
    {
        public ReservationValidator()
        {
            RuleFor(x => x.ClientID)
                .NotNull().WithMessage("Reservation must have a customer.")
                .NotEmpty().WithMessage("Reservation must have a customer.");

            RuleFor(x => x.TourID)
                .NotNull().WithMessage("Reservation must have a trip.")
                .NotEmpty().WithMessage("Reservation must have a trip.");

            RuleFor(x => x.From)
               .NotEmpty().WithMessage("Start Date is required.")
               .LessThanOrEqualTo(x => x.To).WithMessage("Start Date cannot be later than End Date.");

            RuleFor(x => x.To)
                .NotEmpty().WithMessage("End Date is required.")
                .GreaterThanOrEqualTo(x => x.From).WithMessage("End Date cannot be earlier than Start Date");
        }
    }
}