using RMS.Model.viewModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Model.Converters
{
    public class KitchineOrderConverter 
    {
        public DatabaseLayer.OrderCart ConverToEntity(KitchineOrderDTOs model, DatabaseLayer.OrderCart kitchineOrder)
        {
           
            kitchineOrder.OrderDate = model.OrderDate;
            kitchineOrder.OrderNumber = model.OrderNumber;
            kitchineOrder.OrderStatus = (bool)model.OrderStatus;
            return kitchineOrder;
        }
        public KitchineOrderDTOs ConvertToModel(DatabaseLayer.OrderCart model)
        {
            KitchineOrderDTOs kitchineOrder = new KitchineOrderDTOs();
            kitchineOrder.OrderCartID = model.OrderCartID;
            kitchineOrder.OrderDate = model.OrderDate;
            kitchineOrder.OrderNumber = model.OrderNumber;
            kitchineOrder.OrderStatus = model.OrderStatus;
            return kitchineOrder;
        }



        
    }
}