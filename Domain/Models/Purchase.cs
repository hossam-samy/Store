using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }= DateTime.Now;

        public virtual List<PurchaseDetails>  PurchaseDetails { get; set; }

        public int TotalPay { get; set; }

        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
