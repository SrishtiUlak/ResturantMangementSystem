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
    public class CustomerController : Controller
    {
       private readonly CustomerService customerService = new CustomerService();
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            var customers = customerService.GetAll();
            return View(customers);
        }

        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            CustomerDTOs model = new CustomerDTOs();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CustomerDTOs model)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            if (ModelState.IsValid)
            {
              bool result =  customerService.Create(model);
                if (result)
                {
                    return RedirectToAction("Index");
                }

            }
            return View(model);
        }

        public ActionResult Edit(Guid id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            CustomerDTOs model = customerService.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CustomerDTOs model)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            if (ModelState.IsValid)
            {
                bool result = customerService.Update(model);
                if (result)
                {
                    return RedirectToAction("Index");
                }

            }
            return View(model);
        }

        public ActionResult Details(Guid Id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            CustomerDTOs model = customerService.GetById(Id);
            return View(model);
        }

        public ActionResult Delete(Guid Id)
        {
            using(ResturantManagementDBEntities db = new ResturantManagementDBEntities())
            {
                var model = db.Customers.Find(Id);
                db.Customers.Remove(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

    }
}