using Microsoft.EntityFrameworkCore;
using ShopRUs_Discount_API_Minimal.Entities;
using ShopRUs_Discount_API_Minimal.Entities.DtoEntites;

namespace ShopRUs_Discount_API_Minimal.ShopRusDBcontext
{
    public class CustomerDtoProcess : BaseDto, ICustomerDtoProcess
    {
        private readonly ICustomerTypeDtoProcess _customerTypeDtoProcess;

        public CustomerDtoProcess(ICustomerTypeDtoProcess customerTypeDtoProcess)
        {
            _customerTypeDtoProcess = customerTypeDtoProcess;
        }

        public async Task<bool> ExistsCustomer(string nationalId)
        {
            return await shopRUsDBcontext.Customers.AnyAsync(x => x.nationalId == nationalId);
        }

        public async Task<bool> CheckCustomer(int custId)
        {
            return await shopRUsDBcontext.Customers.AnyAsync(x => x.Id == custId);
        }

        public async Task<int> GetCustomerTypeId(int custId)
        {
            var customer = await shopRUsDBcontext.Customers.SingleAsync(x => x.Id == custId);
            return customer.customerTypeId;
        }

        public async Task<ResponseModel<CustomersDTO>> InsertCustomer(CustomersDTO customersDTO)
        {
            var responseModel = new ResponseModel<CustomersDTO>();

            try
            {
                if (await ExistsCustomer(customersDTO.nationalId))
                {
                    responseModel.isSuccess = false;
                    responseModel.reason = "Bu kimlik numaralı müşteri kayıtlı";
                    return responseModel;
                }


                if (!await _customerTypeDtoProcess.ExistCustomerType(customersDTO.customerTypeId))
                {
                    responseModel.isSuccess = false;
                    responseModel.reason = "Geçersiz customerTypeId";
                    return responseModel; 
                }

                await shopRUsDBcontext.Customers.AddAsync(customersDTO);
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
