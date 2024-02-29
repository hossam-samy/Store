

using Microsoft.EntityFrameworkCore;

namespace Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int PurchasePrice { get; set; }
        public int CurrentPrice { get; set; } = 0; 
        public int SellingPrice { get; set; }
        public int NumberInStock { get; set; } 
        public int NumberInStore { get; set; } = 0;
        public int ProductInfoId { get; set; } 

        public virtual ProductInfo  ProductInfo { get; set; }

        public virtual List<ProductSerial>?  ProductSerials { get; set; }
       
       
        

    }
}
