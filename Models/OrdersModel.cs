using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Northwind.WebUI.Models
{
    public class OrdersModel
    {
        public int OrderID { get; set; }

        [Required(ErrorMessage = "The custormer is required.")]
        public string CustomerID { get; set; }

        [Required(ErrorMessage = "The employeee is required.")]
        public int? EmployeeID { get; set; }

        [Required(ErrorMessage = "The oirder date is required.")]
        public DateTime? OrderDate { get; set; }

        [Required]
        [Display(Name = "Required date")]
        public DateTime? RequiredDate { get; set; }
        [Required]
        [Display(Name = "Shipperd date")]
        public DateTime? ShippedDate { get; set; }

        [Required(ErrorMessage = "The Ship via is required.")]
        public int? ShipVia { get; set; }

        [Required(ErrorMessage = "The freight is required.")]
        public decimal? Freight { get; set; }

        [Required(ErrorMessage = "The ship name is required.")]
        public string ShipName { get; set; }

        [Required(ErrorMessage = "The ship address is required.")]
        public string ShipAddress { get; set; }

        [Required(ErrorMessage = "The ship city is required.")]
        public string ShipCity { get; set; }

        [Required(ErrorMessage = "The ship region is required.")]
        public string ShipRegion { get; set; }

        [Required(ErrorMessage = "The ship postal codecis required.")]
        public string ShipPostalCode { get; set; }

        [Required(ErrorMessage = "The ship country is required.")]
        public string ShipCountry { get; set; }

        public List<OrderDetailModel> Detail { get; set; }

    }
}
