using FluentValidation;
using ShopRUs_Discount_API_Minimal.Entities;

namespace ShopRUs_Discount_API_Minimal.Validation
{
    public class CustomersValidation : AbstractValidator<Customers>
    {
        public CustomersValidation()
        {
            RuleFor(x => x.nationalId).NotEmpty().Length(11);
            RuleFor(x => x.name).NotEmpty().MinimumLength(3).MaximumLength(15);
            RuleFor(x => x.surName).NotEmpty().MinimumLength(1).MaximumLength(25);
            RuleFor(x => x.createdDate).NotEmpty();
            RuleFor(x => x.customerTypeId).NotEmpty();
        }
    }
}
