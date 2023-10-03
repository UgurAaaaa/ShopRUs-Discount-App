namespace ShopRUs_Discount_API_Minimal.Entities
{
    public interface IResponseModel
    {
        public bool isSuccess { get; set; }
        public string message { get; set; }
        public string reason { get; set; }
    }
}