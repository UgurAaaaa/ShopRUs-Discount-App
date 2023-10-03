using System.ComponentModel.DataAnnotations;

namespace ShopRUs_Discount_API_Minimal.Entities
{
    public class Customers
    {
        public string nationalId { get; set; }
        public string name { get; set; }
        public string surName { get; set; }
        public DateTime createdDate { get; set; }
        public int customerTypeId { get; set; }
    }
}
