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
    public class VendorController : Controller
    {
        private readonly VendorService vendorServie = new VendorService();
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            var vendors = vendorServie.GetAll();
            return View(vendors);
        }

        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            VendorDTOs model = new VendorDTOs();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(VendorDTOs model)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            if (ModelState.IsValid)
            {
                if (!vendorServie.VendorNameValidation(model.VendorName))
                {

                    bool result = vendorServie.Create(model);
                    if (result)
                    {
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ModelState.AddModelError("VendorName", "Duplicate Vendor Name!");
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
            VendorDTOs model = vendorServie.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(VendorDTOs model)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            if (ModelState.IsValid)
            {
                bool result = vendorServie.Update(model);
                if (result)
                {
                    return RedirectToAction("Index");
                }

            }
            return View(model);
        }

        public ActionResult Details(Guid id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            VendorDTOs model = vendorServie.GetById(id);
            return View(model);
        }

        public ActionResult Delete(Guid id)
        {

            ResturantManagementDBEntities db = new ResturantManagementDBEntities();
            {
                var model = db.Vendors.Find(id);
                db.Vendors.Remove(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}