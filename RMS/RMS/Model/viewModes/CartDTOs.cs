using RMS.Model.viewModes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Model.viewModes
{
    public class CartDTOs
    {

        public CartDTOs()
        {
           
            CustomerNames = new List<BaseGuidSelect>();
            TableNames = new List<BaseGuidSelect>();
        }
        public Guid MenuId { get; set; }

        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public decimal Total { get; set; }

        public string ImagePath { get; set; }

        public string MenuName { get; set; }
        public Guid CustomerID { get; set; }
        public string CustomerName { get; set; }
        public List<BaseGuidSelect> CustomerNames { get; set; }
        public Guid TableID { get; set; }
        public string TableName { get; set; }
        public List<BaseGuidSelect> TableNames { get; set; }


    }

    public class OrderCartsDTOs
    {
        public OrderCartsDTOs()
        {
            Carts = new List<CartDTOs>();
            CustomerNames = new List<BaseGuidSelect>();
            TableNames = new List<BaseGuidSelect>();
        }
        public decimal Total { get; set; }
        public List<CartDTOs> Carts { get; set; }

        public Guid CustomerID { get; set; }
        public string CustomerName { get; set; }
        public List<BaseGuidSelect> CustomerNames { get; set; }
        public Guid TableID { get; set; }
        public string TableName { get; set; }
        public List<BaseGuidSelect> TableNames { get; set; }


    }
}