using Application.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SupplierOperation.Commands.UpdateSupplier
{
    public class UpdateSupplierCommand:IRequest<Response>
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public IFormFile? ImageUrl { get; set; }
    }
}
