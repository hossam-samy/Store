using Application.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SupplierOperation.Commands.AddSupplier
{
    public class AddSupplierCommand:IRequest<Response>
    {
        public string Name { get; set; }
        public IFormFile ImageUrl { get; set; }

    }
}
