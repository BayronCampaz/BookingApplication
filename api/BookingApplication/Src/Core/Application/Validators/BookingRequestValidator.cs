using Domain.Abstractions.RequestModels;
using FluentValidation;

namespace Application.Validators
{
    public class BookingRequestValidator : AbstractValidator<BookingRequest>
    {
        public BookingRequestValidator()
        {
            RuleFor(x => x.EndTime).NotNull().NotEmpty();
            RuleFor(x => x.StartTime).NotNull().NotEmpty();
            RuleFor(x => x.ClientId).NotNull().NotEmpty();
            RuleFor(x => x.TableId).NotNull().NotEmpty();
        }
    }
}
