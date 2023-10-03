using ShopRUs_Discount_API_Minimal.Entities;
using ShopRUs_Discount_API_Minimal.Entities.DtoEntites;

namespace ShopRUs_Discount_API_Minimal.ShopRusDBcontext
{
    public interface IInvoiceDtoProcess
    {
        Task<bool> ExistsInvoice(string invoiceNumber);
        Task<ResponseModel<InvoiceDTO>> InsertInvoice(InvoiceDTO invoiceDTO);
    }
}