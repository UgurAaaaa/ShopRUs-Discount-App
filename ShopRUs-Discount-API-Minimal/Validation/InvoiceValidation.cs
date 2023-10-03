using FluentValidation;
using ShopRUs_Discount_API_Minimal.Entities;

namespace ShopRUs_Discount_API_Minimal.Validation
{
    public class InvoiceValidation : AbstractValidator<Invoice>
    {
        public InvoiceValidation() 
        {
            RuleFor(x => x.invoiceNumber).NotEmpty().MaximumLength(15);
            RuleFor(x => x.customerId).NotEmpty();
            RuleFor(x => x.description).NotEmpty().MaximumLength(100);
            RuleFor(x => x.totalPrice).NotEmpty();
            RuleFor(x => x.invoiceDate).NotEmpty();
        }
    }
}
