using System.ComponentModel.DataAnnotations;

namespace ShopRUs_Discount_API_Minimal.Entities
{
    public class CustomerType
    {
        public string typeName { get; set; }
        public double discountPercent { get; set; }
    }
}
