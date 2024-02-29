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

namespace Application.Features.InvoiceOperation.Commands.CreateInvoice
{
    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateInvoiceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> Handle(CreateInvoiceCommand command, CancellationToken cancellationToken)
        {

            foreach (var item in command.Products)
            {
                var product=_unitOfWork.Repository<ProductInfo>().Get(i=>i.Name==item.Name).Result.FirstOrDefault();

                product.Product.NumberInStock -= item.Quantity;

                await _unitOfWork.Repository<ProductInfo>().Update(product);

            }

            var invoice=_mapper.Map<Invoice>(command);  

            await _unitOfWork.Repository<Invoice>().AddAsync(invoice);  

            return await Response.SuccessAsync("Success");    
        }
    }
}
