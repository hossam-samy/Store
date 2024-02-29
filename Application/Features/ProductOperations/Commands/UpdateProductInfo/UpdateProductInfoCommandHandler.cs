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

namespace Application.Features.ProductOperations.Commands.UpdateProductInfo
{
    public class UpdateProductInfoCommandHandler : IRequestHandler<UpdateProductInfoCommand, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMediaServicecs _mediaService;

        public UpdateProductInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IMediaServicecs mediaService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _mediaService = mediaService;
        }

        public async Task<Response> Handle(UpdateProductInfoCommand command, CancellationToken cancellationToken)
        {
            var productinfo = _unitOfWork.Repository<ProductInfo>().Get(i => i.Name == command.Name).Result.FirstOrDefault();

             productinfo.Evaluation = command.Evaluation ?? productinfo.Evaluation;
            productinfo.LowInInventory = command.LowInInventory ?? productinfo.LowInInventory;

            productinfo.ImageUrl =await _mediaService.UpdateFileAsync(productinfo.ImageUrl, command.ImageUrl, productinfo.Name, "Product");

            await _unitOfWork.Repository<ProductInfo>().Update(productinfo);

            return await Response.SuccessAsync("Success");
        }
    }
}
