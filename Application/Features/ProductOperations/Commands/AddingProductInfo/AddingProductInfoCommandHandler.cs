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

namespace Application.Features.ProductOperations.Commands.AddingProductInfo
{
    internal class AddingProductInfoCommandHandler : IRequestHandler<AddingProductInfoCommand, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;
        private readonly IMediaServicecs _mediaService;

        public AddingProductInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IMediaServicecs mediaService)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
            _mediaService = mediaService;
        }

        public async Task<Response> Handle(AddingProductInfoCommand command, CancellationToken cancellationToken)
        {
            var product = mapper.Map<ProductInfo>(command);
            product.ImageUrl = await _mediaService.AddFileAsync(command.ImageUrl, product.Name, "Product");

           await  _unitOfWork.Repository<ProductInfo>().AddAsync(product);   
            
            return await Response.SuccessAsync("Success");
        }
    }
}
