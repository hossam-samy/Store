using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ProductInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Evaluation { get; set; }
        public string ImageUrl { get; set; }
        public int LowInInventory { get; set; }
        public virtual Product? Product { get; set; }
    }
}
