using DatabaseLayer;
using RMS.Model.Converters;
using RMS.Model.viewModes;
using RMS.Model.viewModes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Model.Services
{
    public class InventoryProductService
    {
        private readonly InventoryProductConverter converter = new InventoryProductConverter();
        private readonly ProductQuantityConverter productconverter = new ProductQuantityConverter();

        public InventoryProductDTOs CreateSelectList(InventoryProductDTOs model)
        {
            model.Categories = GetCategories();
          
            return model;
        }

        public List<BaseGuidSelect> GetCategories()
        {
            using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
            {
                return db.Categories.Select(u =>
                new BaseGuidSelect
                {
                    Id = u.CategoryID,
                    Name = u.CategoryName
                }).ToList();
            }
        }
        

        public bool ProductsNameValidation(string ProducstName)
        {
            using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
            {
                return db.InventoryProducts.Any(u => u.ProductsName.Equals(ProducstName));
            }
        }
        private readonly ProductQuantityDTOs modelQuanity = new ProductQuantityDTOs();

        public bool Create(InventoryProductDTOs model)
        {

            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {
                    DatabaseLayer.InventoryProduct inventoryProduct = new DatabaseLayer.InventoryProduct();
                    inventoryProduct.InventoryProductID = Guid.NewGuid();
                    inventoryProduct = converter.ConverToEntity(model, inventoryProduct);
                    
                    db.InventoryProducts.Add(inventoryProduct);
                    db.SaveChanges();
                    DatabaseLayer.ProductQuantity productQuantity = new DatabaseLayer.ProductQuantity();
                    productQuantity.ProductQuantityID = Guid.NewGuid();
                    productQuantity = productconverter.ConverToEntity(modelQuanity, productQuantity);
                    productQuantity.Quantity = 0;
                    productQuantity.InventoryProductID = inventoryProduct.InventoryProductID;
                    db.ProductQuantities.Add(productQuantity);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception )
            {
                throw;
            }

        }

        public bool Update(InventoryProductDTOs model)
        {
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {

                    DatabaseLayer.InventoryProduct inventoryProduct = db.InventoryProducts.FirstOrDefault(c => c.InventoryProductID == model.InventoryProductID);
                    if (inventoryProduct != null)
                    {
                        inventoryProduct = converter.ConverToEntity(model,inventoryProduct );
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception )
            {
                throw;
            }

        }

        public InventoryProductDTOs GetById(Guid InventoryProductID)
        {
            InventoryProductDTOs model = new InventoryProductDTOs();
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {

                    DatabaseLayer.InventoryProduct inventoryProduct = db.InventoryProducts.FirstOrDefault(c => c.InventoryProductID == InventoryProductID);
                    if (inventoryProduct!= null)
                    {
                        model = converter.ConvertToModel(inventoryProduct);

                    }
                    return model;
                }
            }
            catch (Exception )
            {
                throw;
            }

        }
        public List<InventoryProductDTOs> GetAll()
        {
            List<InventoryProductDTOs> inventoryProducts = new List<InventoryProductDTOs>();
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {

                    var dbInventoryProducts = db.InventoryProducts.ToList();
                    foreach (var inventoryProduct in dbInventoryProducts)
                    {
                        inventoryProducts.Add(converter.ConvertToModel(inventoryProduct));

                    }
                    return inventoryProducts;
                }
            }
            catch (Exception )
            {
                throw;
            }

        }

        public bool Delete(Guid inventoryProductID)
        {

            using (var db = new ResturantManagementDBEntities())
            {

                var inventoryProduct= db.InventoryProducts.FirstOrDefault(x => x.InventoryProductID == inventoryProductID);
                if (inventoryProduct!= null)
                {
                    db.InventoryProducts.Remove(inventoryProduct);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

    }
}