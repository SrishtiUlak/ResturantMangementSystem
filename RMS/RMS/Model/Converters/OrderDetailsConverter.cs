using RMS.Model.viewModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Model.Converters
{
    public class OrderDetailsConverter
    {
        public OrderDetailsDTOs ConvertToModel(DatabaseLayer.OrderCart orderCart, DatabaseLayer.CartDetail cartDetail, DatabaseLayer.Menu menu, DatabaseLayer.Customer customer)
        {
            OrderDetailsDTOs orderDetails = new OrderDetailsDTOs();
            orderDetails.OrderCartID = orderCart.OrderCartID;
            orderDetails.OrderDate = orderCart.OrderDate;
            orderDetails.Quantity = cartDetail.Quantity;
            orderDetails.CustomerName = customer.CustomerName;
            orderDetails.MenuName = menu.MenuName;
            return orderDetails;
        }
    }
}