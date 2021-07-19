using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.WebUI.Models
{
    public class OrderDetailModel
    {
        public string Guid { get; set; }

        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }

        public decimal? Discount { get; set; }

        public decimal Total { get; set; }
    }
}
