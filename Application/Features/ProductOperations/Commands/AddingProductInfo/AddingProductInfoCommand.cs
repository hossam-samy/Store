using Application.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductOperations.Commands.AddingProductInfo
{
    public class AddingProductInfoCommand:IRequest<Response>
    {
        public string Name { get; set; }
        public int Evaluation { get; set; }
        public IFormFile ImageUrl { get; set; }
        public int LowInInventory { get; set; }
    }
}
