using Application.Common;
using Application.Interfaces;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SupplierOperation.Commands.UpdateSupplier
{
    internal class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediaServicecs _mediaServicecs;

        public UpdateSupplierCommandHandler(IUnitOfWork unitOfWork, IMediaServicecs mediaServicecs)
        {
            _unitOfWork = unitOfWork;
            _mediaServicecs = mediaServicecs;
        }

        public async Task<Response> Handle(UpdateSupplierCommand command, CancellationToken cancellationToken)
        {
           var supplier=_unitOfWork.Repository<Supplier>().Get(i=>i.Id==command.Id).Result.FirstOrDefault();    
            if (supplier==null) {
                return await Response.FailureAsync("Faild");
            }
            supplier.Name=command.Name??supplier.Name;

            supplier.ImageUrl =await  _mediaServicecs.UpdateFileAsync(supplier.ImageUrl, command.ImageUrl, command.Name, "Suppliers");

            await _unitOfWork.Repository<Supplier>().Update(supplier);

            return await Response.SuccessAsync("Success");   

        }
    }
}
