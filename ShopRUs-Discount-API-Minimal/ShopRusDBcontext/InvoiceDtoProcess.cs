using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ShopRUs_Discount_API_Minimal.Entities;
using ShopRUs_Discount_API_Minimal.Entities.DtoEntites;

namespace ShopRUs_Discount_API_Minimal.ShopRusDBcontext
{
    public class InvoiceDtoProcess : BaseDto, IInvoiceDtoProcess
    {
        private readonly ICustomerDtoProcess _customerDtoProcess;
        private string _reason = string.Empty;

        public InvoiceDtoProcess(ICustomerDtoProcess customerDtoProcess)
        {
            _customerDtoProcess = customerDtoProcess;
        }

        public async Task<ResponseModel<InvoiceDTO>> InsertInvoice(InvoiceDTO invoiceDTO)
        {
            var responseModel = new ResponseModel<InvoiceDTO>();

            try
            {
                if (!await CheckBeforeInsert(invoiceDTO))
                {
                    responseModel.isSuccess = false;
                    responseModel.reason = _reason;
                    return responseModel;
                }

                await shopRUsDBcontext.Invoice.AddAsync(invoiceDTO);
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

        private async Task<bool> CheckBeforeInsert(InvoiceDTO invoiceDTO)
        {
            if (await ExistsInvoice(invoiceDTO.invoiceNumber.ToString()))
            {
                _reason = "Bu fatura numarası ile bir fatura zaten kayıtlı";
                return false;
            }

            if (!await _customerDtoProcess.CheckCustomer(invoiceDTO.customerId))
            {
                _reason = "Bu müşteri kayıtlı değil";
                return false;
            }

            if (!await CalculateDiscount(invoiceDTO))
                return false;

            return true;
        }

        public async Task<bool> ExistsInvoice(string invoiceNumber)
        {
            return await shopRUsDBcontext.Invoice.AnyAsync(x => x.invoiceNumber.Equals(invoiceNumber));
        }

        public async Task<bool> CalculateDiscount(InvoiceDTO invoiceDTO)
        {
            int custTypeId = await _customerDtoProcess.GetCustomerTypeId(invoiceDTO.customerId);
            var custType = await shopRUsDBcontext.CustomerTypes.FirstOrDefaultAsync(x => x.Id.Equals(custTypeId));
            if (custType == null)
            {
                _reason = "Müşteri tipi bulunamadı";
                return false;
            }
            
            invoiceDTO.discountPer100 = ((int)invoiceDTO.totalPrice / 100) * 5;
            if (!invoiceDTO.isGrocery)
            {
                invoiceDTO.discountForPercent = (invoiceDTO.totalPrice / 100) * custType.discountPercent;
                invoiceDTO.totalDiscount = invoiceDTO.discountPer100 + invoiceDTO.discountForPercent;
            }
            else
                invoiceDTO.totalDiscount = invoiceDTO.discountPer100;
            invoiceDTO.totalNet = invoiceDTO.totalPrice - invoiceDTO.discountForPercent - invoiceDTO.discountPer100;
            return true;
        }
    }
}
