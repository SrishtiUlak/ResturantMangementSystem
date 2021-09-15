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
    public class OrderService
    {
        private readonly OrderConverter converter = new OrderConverter();
        private readonly InventoryProductService inventoryProductService = new InventoryProductService();

        public OrderDTOs CreateSelectList(OrderDTOs model)
        {
           
            model.ProductsName = GetProducts();
            model.Vendors = GetVendors();
        
            return model;
        }

        public List<BaseGuidSelect> GetVendors()
        {
            using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
            {
                return db.Vendors.Select(u =>
                new BaseGuidSelect
                {
                    Id = u.VendorID,
                    Name = u.VendorName
                }).ToList();

                
            }
        }

        public List<BaseGuidSelect> GetProducts()
        {
            using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
            {
                return db.InventoryProducts.Select(u =>
                new BaseGuidSelect
                {
                    Id = u.InventoryProductID,
                    Name = u.ProductsName
                }).ToList();
            }
        }

     

        public bool Create(OrderDTOs model)
        {
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {
                    DatabaseLayer.Order order = new DatabaseLayer.Order();
                    order.OrderID = Guid.NewGuid();
                    order = converter.ConvertToEntity(model, order);

                    db.Orders.Add(order);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public bool Update(OrderDTOs model)
        {
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {

                    DatabaseLayer.Order order = db.Orders.FirstOrDefault(c => c.OrderID == model.OrderID);
                    if (order != null)
                    {
                        order = converter.ConvertToEntity(model, order);
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public OrderDTOs GetById(Guid orderId)
        {
            OrderDTOs model = new OrderDTOs();
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {

                    DatabaseLayer.Order order = db.Orders.FirstOrDefault(c => c.OrderID == orderId);
                    if (order != null)
                    {
                        model = converter.ConvertToModel(order);

                    }
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public List<OrderVM> GetAll()
        {
            List<OrderVM> orders = new List<OrderVM>();
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {

                    var dbOrders = db.Orders.ToList();
                    foreach (var order in dbOrders)
                    {
                        orders.Add(converter.ConvertToOrderModel(order));

                    }
                    return orders;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public bool Delete(Guid orderId)
        {

            using (var db = new ResturantManagementDBEntities())
            {

                var order = db.Orders.FirstOrDefault(x => x.OrderID == orderId);
                if (order != null)
                {
                    db.Orders.Remove(order);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}