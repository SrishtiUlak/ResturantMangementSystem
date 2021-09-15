using DatabaseLayer;
using RMS.Model.Converters;
using RMS.Model.viewModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Model.Services
{
    public class KitchineOrderService
    {
        private readonly KitchineOrderConverter converter = new KitchineOrderConverter();
        private readonly OrderDetailsConverter orderDetailsConverter = new OrderDetailsConverter();
        private OrderDetailsDTOs orderItems;

        public List<KitchineOrderDTOs> GetAll()
        {
            List<KitchineOrderDTOs> orders = new List<KitchineOrderDTOs>();
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {
                                     
                    var orderdate = db.OrderCarts.Where(x => x.OrderDate == DateTime.Today & x.OrderStatus == false).ToList();
                    foreach (var order in orderdate)
                    {
                        {
                            orders.Add(converter.ConvertToModel(order));

                        }
                    }
                    return orders;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public KitchineOrderDTOs GetById(int orderId)
        {
            KitchineOrderDTOs model = new KitchineOrderDTOs();
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {

                    OrderCart order = db.OrderCarts.FirstOrDefault(ca => ca.OrderCartID == orderId);
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


        public bool Update(KitchineOrderDTOs model)
        {
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {

                    OrderCart order = db.OrderCarts.FirstOrDefault(ca => ca.OrderCartID == model.OrderCartID);
                    if (order != null)
                    {
                        order = converter.ConverToEntity(model, order);
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

    }
}