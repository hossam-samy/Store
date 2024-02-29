using Application.Common;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PurchaseOperation.Commands.AddingPurchaseCommand
{
    public class ProductDto
    {

        public string Name { get; set; }
        public int Quantity { get; set; }
        public int PurchasePrice { get; set; }
        public int SellingPrice { get; set; }

    }
    public class AddPurchaseCommand : IRequest<Response>
    {
        public List<ProductDto> Products { get; set; }

        public int SupplierId { get; set; }
    }
}
