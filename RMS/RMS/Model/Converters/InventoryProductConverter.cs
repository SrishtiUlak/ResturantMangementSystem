
using RMS.Model.viewModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Model.Converters
{
    public class InventoryProductConverter
    {
        public DatabaseLayer.InventoryProduct ConverToEntity(InventoryProductDTOs model,DatabaseLayer.InventoryProduct inventoryProduct)
        {
            inventoryProduct.ProductsName = model.ProductsName;
            inventoryProduct.ManufactureDate = model.ManufactureDate;
            inventoryProduct.ExpDate = model.ExpDate;
            inventoryProduct.Description = model.Description;
            inventoryProduct.CategoryID = model.CategoryID;
            
            return inventoryProduct;
        }
        public InventoryProductDTOs ConvertToModel(DatabaseLayer.InventoryProduct model)
        {
            InventoryProductDTOs inventoryProduct = new InventoryProductDTOs();
            inventoryProduct.InventoryProductID = model.InventoryProductID;
            inventoryProduct.ProductsName = model.ProductsName;
            inventoryProduct.ManufactureDate = model.ManufactureDate;
            inventoryProduct.ExpDate = model.ExpDate;
            inventoryProduct.Description = model.Description;
            inventoryProduct.CategoryID = model.CategoryID;
            inventoryProduct.Category = model.Category.CategoryName;
            return inventoryProduct;
        }

        
    }
}