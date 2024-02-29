using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PurchaseOperation.Queries.ViewPurchaseDetails
{
    internal class ViewPurchaseDetailsResponse
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int PurchasePrice { get; set; }
        public int SellingPrice { get; set; }
    }
}
