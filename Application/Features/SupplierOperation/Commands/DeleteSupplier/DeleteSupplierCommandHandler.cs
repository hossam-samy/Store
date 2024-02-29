using Application.Common;
using Application.Interfaces;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SupplierOperation.Commands.DeleteSupplier
{
    internal class DeleteSupplierCommandHandler : IRequestHandler<DeleteSupplierCommand, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediaServicecs _mediaService;

        public DeleteSupplierCommandHandler(IUnitOfWork unitOfWork, IMediaServicecs mediaService)
        {
            _unitOfWork = unitOfWork;
            _mediaService = mediaService;
        }

        public async Task<Response> Handle(DeleteSupplierCommand command, CancellationToken cancellationToken)
        {
            var supplier=_unitOfWork.Repository<Supplier>().Get(i=>i.Id==command.Id).Result.FirstOrDefault();

            if (supplier==null) {

                return await Response.FailureAsync("Faild");
            }
            await _unitOfWork.Repository<Supplier>().Delete(supplier);

            return await Response.SuccessAsync("Success");

        }
    }
}
