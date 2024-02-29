using Application.Common;
using Application.Interfaces;
using Domain.Models;
using Mapster;
using MapsterMapper;
using MediatR;

namespace Application.Features.PurchaseOperation.Commands.AddingPurchaseCommand
{
    internal class AddingPurchaseCommandHandler : IRequestHandler<AddPurchaseCommand, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddingPurchaseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> Handle(AddPurchaseCommand command, CancellationToken cancellationToken)
        {
            var products = new List<Product>();

            foreach (var item in command.Products)
            {
                var productinfo = _unitOfWork.Repository<ProductInfo>().Get(i => i.Name == item.Name).Result.FirstOrDefault();

                Product product;  

                if (productinfo.Product == null)
                {
                         product=_mapper.Map<Product>(item);
                         product.ProductInfo = productinfo;
                }
                else
                {

                    productinfo.Product.NumberInStock += item.Quantity;
                    productinfo.Product.PurchasePrice = item.PurchasePrice;
                    productinfo.Product.SellingPrice = item.SellingPrice;
                    product = productinfo.Product;
                }

                products.Add(product);
            }

            var details = _mapper.Map<List<PurchaseDetails>>(command.Products);

            var purchase = new Purchase { PurchaseDetails=details , SupplierId = command.SupplierId, TotalPay= command.Products.Sum(x => x.Quantity * x.PurchasePrice)};

            await _unitOfWork.Repository<Purchase>().AddAsync(purchase);
            return await Response.SuccessAsync("Success");
        }
    }
}
