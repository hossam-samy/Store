using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.InvoiceOperation.Queries.GetCustomerAllQuery
{
    public class GetAllCustomerResponse
    {
        public virtual List<InvoiceDetails> InvoiceDetails { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
    }
}
