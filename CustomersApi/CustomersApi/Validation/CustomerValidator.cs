using CustomersApi.Core.Model;
using FluentValidation;

namespace CustomersApi.Validation
{
    public class CustomerValidator:AbstractValidator<CustomerModel>
    {
        public CustomerValidator()
        { 
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("please enter name");
            RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress().WithMessage("please enter e-mail address");
            RuleFor(x => x.Address.AddressLine).NotNull().NotEmpty().WithMessage("please enter name");
            RuleFor(x => x.Address.City).NotNull().NotEmpty().WithMessage("please enter city");
            RuleFor(x => x.Address.Country).NotNull().NotEmpty().WithMessage("please enter country");
            RuleFor(x => x.Address.CityCode).NotNull().NotEmpty().When(x=>x.Address.CityCode > 0).WithMessage("please enter CityCode");
        }        
    }
}
