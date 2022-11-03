using Domain.Abstractions.RequestModels;
using Domain.Entities;
using FluentValidation;

namespace Application.Validators
{
    public class RestaurantRequestValidator : AbstractValidator<RestaurantRequest>
    {
        public RestaurantRequestValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Address).NotNull().NotEmpty();
            RuleFor(x => x.City).NotNull().NotEmpty();
        }

    }
}
