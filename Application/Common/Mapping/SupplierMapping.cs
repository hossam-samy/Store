using Application.Features.PurchaseOperation.Commands.AddingPurchaseCommand;
using Application.Features.PurchaseOperation.Queries.GetAllPurchases;
using Application.Features.PurchaseOperation.Queries.ViewPurchaseDetails;
using Application.Features.SupplierOperation.Commands.AddSupplier;
using Application.Features.SupplierOperation.Queries.GetAllSuppliers;
using Domain.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Mapping
{
    public class SupplierMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AddSupplierCommand, Supplier>();
            config.NewConfig<Supplier, GetAllSuppliersResponse>().Map(i=>i.LatestPurchase,i=>i.Purchase.Last().Id);
            config.NewConfig<Purchase, GetAllPurchasesResponse>().Map(i=>i.Name,i=>i.Supplier.Name);
            config.NewConfig<ProductDto, PurchaseDetails>();
            config.NewConfig<PurchaseDetails,ViewPurchaseDetailsQuery>();


        }
    }
}
