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

namespace Application.Features.PurchaseOperation.Queries.GetAllPurchases
{
    internal class GetAllPurchasesQueryHandler : IRequestHandler<GetAllPurchasesQuery, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllPurchasesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> Handle(GetAllPurchasesQuery query, CancellationToken cancellationToken)
        {
            var purchases = await _unitOfWork.Repository<Purchase>().Get(i => i);


            var response=_mapper.Map<IEnumerable<GetAllPurchasesResponse>>(purchases);

            
            return await Response.SuccessAsync(response);   
            
        }
    }
}
