using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace RMS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
            {
                ViewBag.countUser = db.Users.Count();
                ViewBag.countCustomer = db.Customers.Count();
                ViewBag.totalOrder = db.OrderCarts.Count();
                ViewBag.Date = db.OrderCarts.Where(x => x.OrderDate == DateTime.Today).Count();
                return View();
            }

        }
        public ActionResult GetDate()
        {
            using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
            {
                int admin = db.Users.Where(x => x.UserType.Type == "Admin").Count();
                int waiter = db.Users.Where(x => x.UserType.Type == "Waiter").Count();
                int ktichenStaff = db.Users.Where(x => x.UserType.Type == "Ktichen Staff").Count();
                Ratio obj = new Ratio();
                obj.Admin = admin;
                obj.Waiter = waiter;
                obj.KtichenStaff = ktichenStaff;
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
        }
        public class Ratio
        {
            public int Admin { get; set; }
            public int Waiter { get; set; }
            public int KtichenStaff { get; set; }
        }
    }
}