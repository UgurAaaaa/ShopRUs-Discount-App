namespace ShopRUs_Discount_API_Minimal.Entities.DtoEntites
{
    public class CustomersDTO
    {
        public int Id { get; set; }
        public string nationalId { get; set; }
        public string name { get; set; }
        public string surName { get; set; }
        public DateTime createdDate { get; set; }
        public int customerTypeId { get; set; }
    }
}
