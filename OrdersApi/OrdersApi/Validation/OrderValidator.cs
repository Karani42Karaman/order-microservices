using FluentValidation;
using OrdersApi.Core.Model;

namespace OrdersApi.Validation
{
    public class OrderValidator : AbstractValidator<OrderModel>
    {
        public OrderValidator()
        {
            RuleFor(x => x.Price).NotEmpty().When(x => x.Address.CityCode > 0).WithMessage("please enter Price");
            RuleFor(x => x.Quantity).NotEmpty().When(x => x.Address.CityCode > 0).WithMessage("please enter Quantity");
            RuleFor(x => x.Price).NotEmpty().When(x => x.Address.CityCode > 0).WithMessage("please enter Price");
            RuleFor(x => x.CustomerId).NotEmpty().NotEmpty().WithMessage("please enter CustomerId");
            RuleFor(x => x.Address.AddressLine).NotNull().NotEmpty().WithMessage("please enter AddressLine");
            RuleFor(x => x.Address.City).NotNull().NotEmpty().WithMessage("please enter city");
            RuleFor(x => x.Address.Country).NotNull().NotEmpty().WithMessage("please enter country");
            RuleFor(x => x.Address.CityCode).NotNull().NotEmpty().When(x => x.Address.CityCode > 0).WithMessage("please enter CityCode");

        }
    }
}
