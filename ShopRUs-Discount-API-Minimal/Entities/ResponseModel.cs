namespace ShopRUs_Discount_API_Minimal.Entities
{
    public class ResponseModel<T> : IResponseModel 
    {      
        public string message { get; set; }
        public string reason { get; set; }
        public T data { get; set; }

        private bool mySuccess;
        public bool isSuccess
        {
            get { return mySuccess; }
            set { mySuccess = value;
                if (mySuccess == false)
                    message = "İşlem başarısız";
                else
                    message = "İşlem başarılı";
            }
        }
    }
}
