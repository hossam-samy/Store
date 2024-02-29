using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductOperations.Queries.GetAllProducts
{
    public class GetAllProductsResponse
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int PurchasePrice { get; set; }
        public int CurrentPrice { get; set; }
        public int SellingPrice { get; set; }
        public int NumberInStock { get; set; }
        public int NumberInStore { get; set; }
    }
}
