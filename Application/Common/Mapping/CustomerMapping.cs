using Application.Features.InvoiceOperation.Commands.CreateInvoice;
using Application.Features.InvoiceOperation.Queries.GetAllQuery;
using Application.Features.InvoiceOperation.Queries.GetCustomerAllQuery;
using Domain.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Mapping
{
    public class CustomerMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ProductInvoiceDto, InvoiceDetails>();
            
            config.NewConfig<CreateInvoiceCommand, Invoice>().Map(i=>i.InvoiceDetails,i=>i.Products);
            config.NewConfig<Invoice, GetAllCustomerResponse>();

        }
    }
}
