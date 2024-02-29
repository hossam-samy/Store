using Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.InvoiceOperation.Commands.CreateInvoice
{
    public class ProductInvoiceDto
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int ItemPrice { get; set; }
        public int Total { get; set; }
    }

    public class CreateInvoiceCommand:IRequest<Response>
    {
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public List<ProductInvoiceDto>  Products { get; set; }
    }
}
