using Application.Common;
using Application.Interfaces;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductOperations.Commands.DeleteProductInfo
{
    internal class DeleteProductInfoCommandHandler : IRequestHandler<DeleteProductInfoCommand, Response>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductInfoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> Handle(DeleteProductInfoCommand command, CancellationToken cancellationToken)
        {
            var productinfo= _unitOfWork.Repository<ProductInfo>().Get(i=>i.Name==command.Name).Result.FirstOrDefault();

            await _unitOfWork.Repository<ProductInfo>().Delete(productinfo);

            return await Response.SuccessAsync("Success");    

        }
    }
}
