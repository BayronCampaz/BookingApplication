using Domain.Abstractions.RequestModels;
using FluentValidation;

namespace Application.Validators
{
    public class TableRequestValidator : AbstractValidator<TableRequest>
    {
        public TableRequestValidator()
        {
            RuleFor(x => x.Number).NotNull().NotEmpty();
            RuleFor(x => x.Description).NotNull().NotEmpty();
            RuleFor(x => x.RestaurantId).NotNull().NotEmpty();
        }
    }
}
