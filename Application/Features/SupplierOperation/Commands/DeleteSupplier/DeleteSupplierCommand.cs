using Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SupplierOperation.Commands.DeleteSupplier
{
    public class DeleteSupplierCommand:IRequest<Response>
    {
        public int Id { get; set; }
    }
}
