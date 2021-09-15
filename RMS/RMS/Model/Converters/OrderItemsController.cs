using RMS.Model.viewModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Model.Converters
{
    public class OrderItemsController
    {
        public DatabaseLayer.Order ConverToEntity(OrderItemsDTOs model, DatabaseLayer.Order order)
        {
            order.OrderID = model.OrderID;
            order.OrderDate = model.OrderDate;
            order.OrderTime = model.OrderTime;
            order.Total = model.Total;
            order.OrderName = model.OrderName;
            order.VendorID = model.VendorID;
            return order;
        }
        public OrderItemsDTOs ConvertToModel(DatabaseLayer.Order model)
        {
            OrderItemsDTOs order = new OrderItemsDTOs();
            order.OrderID = model.OrderID;
            order.OrderDate = model.OrderDate;
            order.OrderTime = model.OrderTime;
            order.Total = model.Total;
            order.OrderName = model.OrderName;
            order.VendorID = model.VendorID;
            order.Vendor = model.Vendor.VendorName;
            return order;
        }

    }
}
