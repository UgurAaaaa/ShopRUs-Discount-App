namespace ShopRUs_Discount_API_Minimal.Entities.DtoEntites
{
    public class InvoiceDTO
    {
        public int Id { get; set; }
        public string invoiceNumber { get; set; }
        public int customerId { get; set; }
        public string description { get; set; }
        public double discountPer100 { get; set; }
        public double discountForPercent { get; set; }
        public double totalDiscount { get; set; }
        public double totalPrice { get; set; }
        public double totalNet { get; set; }
        public DateTime invoiceDate { get; set; }
        public bool isGrocery { get; set; }
    }
}
