using ShopRUs_Discount_API_Minimal.Entities.DtoEntites;
using ShopRUs_Discount_API_Minimal.ShopRusDBcontext;

namespace ShopRUsTest
{
    public class ShopRUsDiscountTest
    {
        [Fact]
        public async Task IsGrocery_Test()// market ise yüzdelik indirim yapılmaması gerekiyor
        {
            bool isGrocery = true;
            double expected = 0;

            InvoiceDtoProcess invoiceDtoProcess = new InvoiceDtoProcess();
            InvoiceDTO invoice = new InvoiceDTO { 
                customerId = 1,                
                isGrocery = isGrocery,
                totalPrice = 450.00
            };
            await invoiceDtoProcess.CalculateDiscount(invoice);

            Assert.Equal(expected, invoice.discountForPercent);
        }
    }
}