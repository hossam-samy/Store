using Application.Features.ProductOperations.Commands.AddingProductInfo;
using Application.Features.ProductOperations.Commands.UpdateProductInfo;
using Application.Features.ProductOperations.Queries.GetAllProductInfos;
using Application.Features.ProductOperations.Queries.GetAllProducts;
using Application.Features.PurchaseOperation.Commands.AddingPurchaseCommand;
using Domain.Models;
using Mapster;

namespace Application.Common.Mapping
{
    public class ProductInfoMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AddingProductInfoCommand, ProductInfo>();

            config.NewConfig<UpdateProductInfoCommand, ProductInfo>();

            config.NewConfig<ProductInfo,GetAllProductInfosResponse>();

            config.NewConfig<ProductDto, Product>();


            config.NewConfig<ProductInfo, GetAllProductsResponse>().Map(i=>i,i=>i.Product);
        }
    }
}
