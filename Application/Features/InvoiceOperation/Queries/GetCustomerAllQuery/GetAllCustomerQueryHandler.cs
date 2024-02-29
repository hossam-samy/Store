using Application.Common;
using Application.Features.InvoiceOperation.Queries.GetAllQuery;
using Application.Interfaces;
using Domain.Models;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.InvoiceOperation.Queries.GetCustomerAllQuery
{
    internal class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQuery, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCustomerQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> Handle(GetAllCustomerQuery query, CancellationToken cancellationToken)
        {
            var invoices = await _unitOfWork.Repository<Invoice>().Get(i => i);

            var response=_mapper.Map<IEnumerable<GetAllCustomerResponse>>(invoices);  
            
            return await Response.SuccessAsync(response);   
            
        }
    }
}
