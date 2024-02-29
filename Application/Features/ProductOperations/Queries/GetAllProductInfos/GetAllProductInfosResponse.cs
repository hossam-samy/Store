using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductOperations.Queries.GetAllProductInfos
{
    public class GetAllProductInfosResponse
    {
        public string Name { get; set; }
        public int Evaluation { get; set; }
        public string ImageUrl { get; set; }
        public int LowInInventory { get; set; }
    }

}
