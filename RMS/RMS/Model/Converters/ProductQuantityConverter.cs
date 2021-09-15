using RMS.Model.viewModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Model.Converters
{
    public class ProductQuantityConverter
    {

        public DatabaseLayer.ProductQuantity ConverToEntity(ProductQuantityDTOs model, DatabaseLayer.ProductQuantity productQuantity)
        {
            productQuantity.Quantity = model.Quantity;
            productQuantity.InventoryProductID = model.InventoryProductID;
       
      
            return productQuantity;
        }
        public ProductQuantityDTOs ConvertToModel(DatabaseLayer.ProductQuantity model)
        {
            ProductQuantityDTOs productQuantity = new ProductQuantityDTOs();
            productQuantity.Quantity = model.Quantity;
            productQuantity.InventoryProductID = model.InventoryProductID;
            productQuantity.ProductQuantityID = model.ProductQuantityID;
            
            return productQuantity;
        }


    }
}