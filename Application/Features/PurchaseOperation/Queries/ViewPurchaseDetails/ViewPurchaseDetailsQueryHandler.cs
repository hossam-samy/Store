using Application.Common;
using Application.Interfaces;
using Domain.Models;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PurchaseOperation.Queries.ViewPurchaseDetails
{
    internal class ViewPurchaseDetailsQueryHandler : IRequestHandler<ViewPurchaseDetailsQuery, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ViewPurchaseDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> Handle(ViewPurchaseDetailsQuery query, CancellationToken cancellationToken)
        {
            var purchase=_unitOfWork.Repository<Purchase>().Get(i=>i.Id==query.Id).Result.FirstOrDefault();

           // var a = purchase.PurchaseDetails;
            
            var Purchasedetails=_mapper.Map<List<ViewPurchaseDetailsResponse>>(purchase.PurchaseDetails);

            return await Response.SuccessAsync(Purchasedetails);
            
        }
    }
}
