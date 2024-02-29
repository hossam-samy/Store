using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SupplierOperation.Queries.GetAllSuppliers
{
    public class GetAllSuppliersResponse
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string LatestPurchase { get; set; }

        
    }
}
