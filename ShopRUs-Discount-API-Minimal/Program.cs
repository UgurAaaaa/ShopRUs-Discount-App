using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ShopRUs_Discount_API_Minimal.Entities;
using ShopRUs_Discount_API_Minimal.Entities.DtoEntites;
using ShopRUs_Discount_API_Minimal.Mapping;
using ShopRUs_Discount_API_Minimal.ShopRusDBcontext;
using ShopRUs_Discount_API_Minimal.Validation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
#region Customers
builder.Services.AddScoped<IValidator<Customers>, CustomersValidation>();
builder.Services.AddScoped<ICustomerDtoProcess, CustomerDtoProcess>();
#endregion Customers
#region CustomerTypes
builder.Services.AddScoped<ICustomerTypeDtoProcess, CustomerTypeDtoProcess>();
builder.Services.AddScoped<IValidator<CustomerType>, CustomerTypesValidation>();
#endregion CustomerTypes
#region Invoice
builder.Services.AddScoped<IInvoiceDtoProcess, InvoiceDtoProcess>();
builder.Services.AddScoped<IValidator<Invoice>, InvoiceValidation>();
#endregion Invoice
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/CreateCustomerType", async (IValidator<CustomerType> validatorCustomerType, IMapper mapper, ICustomerTypeDtoProcess customerTypeDtoProcess, [FromBody] CustomerType customerType) =>
{
    var customerTypeValidationResult = await validatorCustomerType.ValidateAsync(customerType);
    if (!customerTypeValidationResult.IsValid)
        return Results.BadRequest(customerTypeValidationResult.ToDictionary());

    CustomerTypeDTO customerTypeDTO = mapper.Map<CustomerTypeDTO>(customerType);

    var responseModel = await customerTypeDtoProcess.InsertCustomerType(customerTypeDTO);
    if (responseModel.isSuccess)
        return Results.Ok(new { message = responseModel.message, data = customerTypeDTO });

    return Results.BadRequest(responseModel);
});

app.MapPost("/CreateCustomer", async (IValidator<Customers> validatorCustomer, IMapper mapper, ICustomerDtoProcess customerDtoProcess, [FromBody] Customers customers) =>
{
    var customersValidationResult = await validatorCustomer.ValidateAsync(customers);
    if (!customersValidationResult.IsValid)
        return Results.BadRequest(customersValidationResult.ToDictionary());    

    CustomersDTO customersDTO = mapper.Map<CustomersDTO>(customers);

    var responseModel = await customerDtoProcess.InsertCustomer(customersDTO);
    if (responseModel.isSuccess)
        return Results.Ok(new { message = responseModel.message, data = customersDTO });

    return Results.BadRequest(responseModel);
});

app.MapPost("/CalcInvoiceDiscount", async (IValidator<Invoice> invoiceValidator, IMapper mapper, IInvoiceDtoProcess invoiceDtoProcess, [FromBody] Invoice invoice) =>
{
    var invoiceValidationResult = await invoiceValidator.ValidateAsync(invoice);
    if (!invoiceValidationResult.IsValid)
        return Results.BadRequest(invoiceValidationResult.ToDictionary());    

    InvoiceDTO invoiceDTO = mapper.Map<InvoiceDTO>(invoice);

    var responseModel = await invoiceDtoProcess.InsertInvoice(invoiceDTO);
    if (responseModel.isSuccess)
        return Results.Ok(new { message = responseModel.message, data = invoiceDTO });        

    return Results.BadRequest(responseModel);
});

app.Run();