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
    public class OrderItemsService
    {
        private readonly OrderItemsController converter = new OrderItemsController();

        public OrderItemsDTOs CreateSelectList(OrderItemsDTOs model)
        {
            model.Vendors = GetTableTypes();
            return model;
        }

        public List<BaseGuidSelect> GetTableTypes()
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

        public List<OrderItemsDTOs> GetAll()
        {
            List<OrderItemsDTOs> orderItems = new List<OrderItemsDTOs>();
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {

                    var dborder = db.Orders.ToList();
                    foreach (var order in dborder)
                    {
                        orderItems.Add(converter.ConvertToModel(order));

                    }
                    return orderItems;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

    }
}