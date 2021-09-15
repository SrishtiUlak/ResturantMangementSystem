using RMS.Model.viewModes.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMS.Model.viewModes
{
    public class InvoiceDTOs
    {
        public InvoiceDTOs()
        {
            OrderCarts = new List<BaseIdSelect>();
        }


        public System.Guid InvoiceID { get; set; }
        public bool ? Status { get; set; }
        public int OrderCartID { get; set; }
        public List<BaseIdSelect> OrderCarts { get; set; }
        public string OrderCart { get; set; }
    }


    public class InvoiceIndexDTOs
    {
        public string OrderID { get; set; }
        public int OrderCartID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }
        public Guid ItemID { get; set; }
        public decimal? Quantity { get; set; }
        public string Price { get; set; }
        public decimal mon { get; set; }
        public Guid InventoryProductID { get; set; }
        public string CustomerName { get; set; }
        public string Dish { get; set; }
        public int SubTotal { get; set; }
        public string TableName { get; set; }
        public Guid InvoiceID { get; set; }
    }
}