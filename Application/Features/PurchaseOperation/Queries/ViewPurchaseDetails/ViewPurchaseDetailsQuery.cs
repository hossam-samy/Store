using Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PurchaseOperation.Queries.ViewPurchaseDetails
{
    public class ViewPurchaseDetailsQuery:IRequest<Response>
    {
        public int Id { get; set; }
    }
}
