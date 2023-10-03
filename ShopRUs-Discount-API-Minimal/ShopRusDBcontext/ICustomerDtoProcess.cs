using ShopRUs_Discount_API_Minimal.Entities;
using ShopRUs_Discount_API_Minimal.Entities.DtoEntites;

namespace ShopRUs_Discount_API_Minimal.ShopRusDBcontext
{
    public interface ICustomerDtoProcess
    {
        Task<bool> ExistsCustomer(string nationalId);
        Task<bool> CheckCustomer(int custId);
        Task<int> GetCustomerTypeId(int custId);
        Task<ResponseModel<CustomersDTO>> InsertCustomer(CustomersDTO customersDTO);
    }
}