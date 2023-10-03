using AutoMapper;
using ShopRUs_Discount_API_Minimal.Entities;
using ShopRUs_Discount_API_Minimal.Entities.DtoEntites;

namespace ShopRUs_Discount_API_Minimal.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Customers
            CreateMap<Customers, CustomersDTO>();
            CreateMap<CustomersDTO, Customers>();
            #endregion Customers

            #region CustomerTypes
            CreateMap<CustomerType, CustomerTypeDTO>();
            CreateMap<CustomerTypeDTO, CustomerType>();
            #endregion CustomerTypes

            #region Invoice
            CreateMap<Invoice, InvoiceDTO>();
            CreateMap<InvoiceDTO, Invoice>();
            #endregion Invoice
        }
    }
}
