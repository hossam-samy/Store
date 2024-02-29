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

namespace Application.Features.ProductOperations.Queries.GetAllProducts
{
    internal class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
        {
            var products =await _unitOfWork.Repository<ProductInfo>().Get(i => i);

            var productsList =_mapper.Map<IEnumerable<GetAllProductsResponse>>(products); 
            
            return await Response.SuccessAsync(productsList);   

        }
    }
}
