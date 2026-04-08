using Application.DTO;
using FluentValidation;

namespace Application.Validators;

public class UpdateOrderDtoValidator : AbstractValidator<UpdateOrderDto>
{
    public UpdateOrderDtoValidator()
    {
        RuleFor(x => x.CustomerId)
            .Length(5)
            .When(x => x.CustomerId != null);

        RuleFor(x => x.Freight)
            .GreaterThanOrEqualTo(0)
            .When(x => x.Freight.HasValue);

        RuleFor(x => x.RequiredDate)
            .GreaterThan(x => x.OrderDate)
            .When(x => x.OrderDate.HasValue && x.RequiredDate.HasValue);
    }
}