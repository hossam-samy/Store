using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Owned]
    public class ProductSerial
    {

        public  string Serial { get; set; }
    }
}
