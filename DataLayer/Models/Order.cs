using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? Require { get; set; }
        public DateTime? Shipped { get; set; }       
        public int? Freight { get; set; }
        public string? ShipName { get; set; }
        public string? ShipCity { get; set; }
    }
}
