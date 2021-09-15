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
    public class InvoiceController : Controller
    {
        private readonly InvoiceService invoiceService = new InvoiceService();
        private ResturantManagementDBEntities db = new ResturantManagementDBEntities();

        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            //var invoice = invoiceService.GetAll();
            IEnumerable<InvoiceIndexDTOs> ListOfCartDetails = (from o in db.OrderCarts
                                                                join oI in db.CartDetails on o.OrderCartID equals oI.OrderCartID
                                                                join t in db.Tables on oI.TableID equals t.TableID
                                                                join i in db.Invoices on oI.OrderCartID equals i.OrderCartID
                                                                where o.OrderStatus == true && o.OrderDate == DateTime.Today && i.Status== false && o.OrderCartID == oI.OrderCartID
                                                               select new InvoiceIndexDTOs()
                                                                                            {
                                                                                                TableName = t.TableName,
                                                                                                OrderCartID = o.OrderCartID,
                                                               }).ToList();

            return View(ListOfCartDetails);
        }


        public ActionResult Details(int? orderCartID)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            IEnumerable<InvoiceIndexDTOs> ListOfCartDetails = (from o in db.OrderCarts
                                                               join oI in db.CartDetails on o.OrderCartID equals oI.OrderCartID
                                                               join t in db.Tables on oI.TableID equals t.TableID
                                                               join me in db.Menus on oI.MenuID equals me.MenuID
                                                               join c in db.Customers on oI.CustomerID equals c.CustomerID
                                                               join i in db.Invoices on oI.OrderCartID equals i.OrderCartID
                                                               where   o.OrderCartID == orderCartID
                                                               select new InvoiceIndexDTOs()
                                                               {
                                                                   OrderID = o.OrderNumber,
                                                                   OrderCartID = o.OrderCartID,
                                                                   OrderDate = o.OrderDate,
                                                                   TableName = t.TableName,
                                                                   CustomerName = c.CustomerName,
                                                                   Price = me.MenuPrice,
                                                                   Quantity =  oI.Quantity,
                                                                   Total = oI.Total,
                                                                   Dish = me.MenuPrice,
                                                                   InvoiceID = i.InvoiceID

                                                               }).ToList();

            return View(ListOfCartDetails);
        }
        public ActionResult Edit(Guid invoice)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            InvoiceDTOs model = invoiceService.GetById(invoice);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(InvoiceDTOs model)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            if (ModelState.IsValid)
            {
                bool result = invoiceService.Update(model);
                if (result)
                {
                    return RedirectToAction("Index");
                }

            }
            return View(model);
        }
      
    }
}