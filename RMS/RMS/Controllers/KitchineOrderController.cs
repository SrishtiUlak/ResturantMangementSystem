using DatabaseLayer;
using RMS.Model.Services;
using RMS.Model.viewModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RMS.Controllers
{
    public class KitchineOrderController : Controller
    {
        private readonly KitchineOrderService orderService = new KitchineOrderService();
        // GET: KitchineOrder
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            var order = orderService.GetAll();
            return View(order);
        }

        private ResturantManagementDBEntities db;
       
        public KitchineOrderController()
        {
            db = new ResturantManagementDBEntities();
        }
        public ActionResult OrderDetails(int? orderCartID)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
            {
                IEnumerable<OrderDetailsDTOs> orderItems = (from o in db.OrderCarts
                                                            join oI in db.CartDetails on o.OrderCartID equals oI.OrderCartID
                                                            join me in db.Menus on oI.MenuID equals me.MenuID
                                                            where o.OrderCartID == orderCartID
                                                            select new OrderDetailsDTOs()
                                                            {
                                                                OrderCartID = o.OrderCartID,
                                                                OrderDate = o.OrderDate,
                                                                CustomerName = oI.Customer.CustomerName,
                                                                Quantity = oI.Quantity,
                                                                MenuName = me.MenuName

                                                            }
                    ).ToList();



                return View(orderItems);
            }
        }


        public ActionResult Edit(int orderId)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            KitchineOrderDTOs model = orderService.GetById(orderId);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(KitchineOrderDTOs model)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            if (ModelState.IsValid)
            {
                bool result = orderService.Update(model);
                if (result)
                {
                    return RedirectToAction("Index");
                }

            }
            return View(model);
        }
    }
}


