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

namespace Application.Features.SupplierOperation.Commands.AddSupplier
{
    internal class AddSupplierCommandHandler : IRequestHandler<AddSupplierCommand, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMediaServicecs _mediaService;

        public AddSupplierCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IMediaServicecs mediaService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _mediaService = mediaService;
        }

        public async Task<Response> Handle(AddSupplierCommand command, CancellationToken cancellationToken)
        {
            var supplier = _mapper.Map<Supplier>(command);
            supplier.ImageUrl = await _mediaService.AddFileAsync(command.ImageUrl, command.Name, "Suppliers");

            await _unitOfWork.Repository<Supplier>().AddAsync(supplier);

            return await Response.SuccessAsync("Success");
        }
    }
}
