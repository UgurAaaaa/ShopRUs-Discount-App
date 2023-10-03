using ShopRUs_Discount_API_Minimal.Entities;
using ShopRUs_Discount_API_Minimal.Entities.DtoEntites;

namespace ShopRUs_Discount_API_Minimal.ShopRusDBcontext
{
    public interface ICustomerTypeDtoProcess
    {
        Task<bool> ExistCustomerType(int customerTypeID);
        Task<ResponseModel<CustomerTypeDTO>> InsertCustomerType(CustomerTypeDTO customerTypeDTO);
    }
}