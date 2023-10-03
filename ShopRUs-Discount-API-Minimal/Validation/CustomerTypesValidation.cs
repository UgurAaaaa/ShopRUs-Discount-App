using ShopRUs_Discount_API_Minimal.Entities;
using FluentValidation;

namespace ShopRUs_Discount_API_Minimal.Validation
{
    public class CustomerTypesValidation : AbstractValidator<CustomerType>
    {
        public CustomerTypesValidation()
        {
            RuleFor(x => x.typeName).NotEmpty();
            RuleFor(x => x.discountPercent).NotEmpty().GreaterThan(0).LessThan(100);
        }
    }
}
