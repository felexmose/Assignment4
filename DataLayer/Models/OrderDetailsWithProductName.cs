using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class OrderDetailsWithProductName
    {              
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }        
        public string ProductName { get; set; }
    }
}
