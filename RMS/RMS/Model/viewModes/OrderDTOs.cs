using RMS.Model.viewModes.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMS.Model.viewModes
{
    public class OrderDTOs
    {
        public  OrderDTOs()
        {
           Vendors = new List<BaseGuidSelect>();

            ProductsName = new List<BaseGuidSelect>();
           

        }
        public Guid OrderID { get; set; }
        [Required(ErrorMessage = "Order Time is required")]
        public TimeSpan ? OrderTime { get; set; }
        [Required(ErrorMessage = "Order Date is required")]
        public DateTime OrderDate { get; set; }
        public Guid VendorID { get; set; }
        public List<BaseGuidSelect> ProductsName { get; set; } 
        public string OrderName { get; set; }
        public string ProductName { get; set; }
        public List<BaseGuidSelect> Vendors { get; set; }


        public string Vendor { get; set; }
       
        public List<DropDownOrder> DDItems { get; set; }
        public List<OrderItems> OrderItems { get; set; }
        public List<OrderVM> OrderVMs { get; set; }
    }
    public class CustomerOrder
    {
        public Guid OrderID { get; set; }
        public TimeSpan ? OrderTime { get; set; }
        [Required(ErrorMessage = "Order Date is required")]
        public DateTime OrderDate { get; set; }
        [Required(ErrorMessage = "Total is required")]

        public string Total { get; set; }
        public Guid VendorID { get; set; }
        public string VendorName { get; set; }

        public string Contact { get; set; }
       
        public Guid InventoryProductID { get; set; }

        public string ProductName { get; set; }

        public Guid DishCategoryID { get; set; }

        public Guid DishSubCategoryID { get; set; }
        public string DishCategoryName { get; set; }

        public string DishSubCategoryName { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public double SubTotal { get; set; }
    }

    public class OrderVM
    {
        public Guid OrderID { get; set; }
        public string Vendor { get; set; }

        public TimeSpan OrderTime { get; set; }
        public DateTime OrderDate { get; set; }
        public string ProductName { get; set; }
        public string OrderName { get; set; }


        public int? Quantity { get; set; }

        public string Price { get; set; }

        public string Total { get; set; }
    }

    public class OrderViews
    {
        public Guid OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public string Total { get; set; }
        public Guid VendorID { get; set; }
        public string VenderName { get; set; }
        public string OrderName { get; set; }
        public Guid ItemID { get; set; }
        public int? Quantity { get; set; }
        public string Price { get; set; }
        public Guid InventoryProductID { get; set; }
        public string ProductsName { get; set; }
        public Guid CategoryID { get; set; }
        public string CategoryName { get; set; }

        public int SubTotal { get; set; }

    }


}
public class OrderItems
    {

         public Guid InventoryProductID { get; set; }

        public int Quantity { get; set; }

        public string Price { get; set; }

        public double SubTotal { get; set; }
    }

    public class DropDownOrder
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Price { get; set; }
    }

   
