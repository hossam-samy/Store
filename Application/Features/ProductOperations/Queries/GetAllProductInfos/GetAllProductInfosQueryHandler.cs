using Application.Common;
using Application.Interfaces;
using Domain.Models;
using MapsterMapper;
using MediatR;

namespace Application.Features.ProductOperations.Queries.GetAllProductInfos
{
    internal class GetAllProductInfosQueryHandler : IRequestHandler<GetAllProductInfosQuery, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllProductInfosQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> Handle(GetAllProductInfosQuery query, CancellationToken cancellationToken)
        {
            var productsInfos = await _unitOfWork.Repository<ProductInfo>().Get(i => i);

            var respnse=_mapper.Map<IEnumerable<GetAllProductInfosResponse>>(productsInfos);   
            
            return await Response.SuccessAsync(respnse);    
        }
    }
}
