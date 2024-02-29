using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Owned]
    public class PurchaseDetails
    {

        public string Name { get; set; }
        public int Quantity { get; set; }
        public int PurchasePrice { get; set; }
        public int SellingPrice { get; set; }
    }
}
