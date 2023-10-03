using Microsoft.EntityFrameworkCore;
using ShopRUs_Discount_API_Minimal.Entities;
using ShopRUs_Discount_API_Minimal.Entities.DtoEntites;

namespace ShopRUs_Discount_API_Minimal.ShopRusDBcontext
{
    public class CustomerTypeDtoProcess : BaseDto, ICustomerTypeDtoProcess
    {
        public async Task<bool> ExistCustomerType(int customerTypeID)
        {
            return await shopRUsDBcontext.CustomerTypes.AnyAsync(x => x.Id.Equals(customerTypeID));
        }

        public async Task<ResponseModel<CustomerTypeDTO>> InsertCustomerType(CustomerTypeDTO customerTypeDTO)
        {
            var responseModel = new ResponseModel<CustomerTypeDTO>();
            try
            {
                await shopRUsDBcontext.CustomerTypes.AddAsync(customerTypeDTO);
                if (await shopRUsDBcontext.SaveChangesAsync() > 0)
                    responseModel.isSuccess = true;
            }
            catch (Exception ex)
            {
                responseModel.isSuccess = false;
                throw new Exception(ex.Message);
            }

            return responseModel;
        }
    }
}
