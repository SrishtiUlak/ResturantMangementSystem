using RMS.Model.viewModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Model.Converters
{
    public class OrderConverter
    {
        public DatabaseLayer.Order ConvertToEntity(OrderDTOs model, DatabaseLayer.Order order)
        {
            order.OrderTime = model.OrderTime;
            order.OrderDate = model.OrderDate;        
            order.OrderName = model.OrderName;
          
           
            return order;
        }

        public OrderDTOs ConvertToModel(DatabaseLayer.Order model)
        {
            OrderDTOs order = new OrderDTOs();
            order.OrderID = model.OrderID;
            order.OrderName = model.OrderName;
            order.OrderDate = model.OrderDate;
            order.Vendor = model.Vendor.VendorName;            
            return order;
        }

        public OrderVM ConvertToOrderModel(DatabaseLayer.Order entity)
        {
            var orderVM = new OrderVM
            {
                OrderDate = entity.OrderDate,
                OrderTime = (TimeSpan)entity.OrderTime,
                Vendor = entity.Vendor.VendorName,
                OrderName = entity.OrderName,
                ProductName = entity.OrderItems.FirstOrDefault()?.InventoryProduct.ProductsName,
            
                //Name = entity.Name
            };

            foreach(var item in entity.OrderItems)
            {
                orderVM.Price = item.Price;
                orderVM.Quantity = item.Quantity;
             
                orderVM.ProductName = item.InventoryProduct.ProductsName; //not entity, should be item
                if(item.Quantity != null)//item.Price tryparse if only true
                    orderVM.Total = (item.Quantity * Convert.ToInt32(item.Price)).ToString();
            }
            return orderVM;
        }
    }
}