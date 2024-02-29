using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Owned]
    public class InvoiceDetails
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int ItemPrice { get; set; }
        public int Total { get; set; }

    }
}
