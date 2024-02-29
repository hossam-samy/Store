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

namespace Application.Features.SupplierOperation.Queries.GetAllSuppliers
{
    internal class GetAllSuppliersQueryHandler : IRequestHandler<GetAllSuppliersQuery, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllSuppliersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> Handle(GetAllSuppliersQuery query, CancellationToken cancellationToken)
        {
            var suppliers =await _unitOfWork.Repository<Supplier>().Get(i => i);


            var response = _mapper.Map<IEnumerable<GetAllSuppliersResponse>>(suppliers);

            return await Response.SuccessAsync(response);
            
        }
    }
}
