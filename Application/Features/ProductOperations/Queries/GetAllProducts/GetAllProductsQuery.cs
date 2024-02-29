using Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductOperations.Queries.GetAllProducts
{
    public class GetAllProductsQuery:IRequest<Response>
    {
    }
}
