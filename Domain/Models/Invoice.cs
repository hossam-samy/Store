using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime  Date { get; set; }= DateTime.Now;
        public virtual List<InvoiceDetails> InvoiceDetails { get; set; }


        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
    }
}
