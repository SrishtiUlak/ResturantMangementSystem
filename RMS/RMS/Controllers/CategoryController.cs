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
    public class CategoryController : Controller
    {
        private readonly CategoryService categoryServie = new CategoryService();
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            var categories = categoryServie.GetAll();
            return View(categories);
        }

        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            CategoryDTOs model = new CategoryDTOs();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CategoryDTOs model)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }

            if (ModelState.IsValid)
            {
                if (!categoryServie.CategoryNameValidation(model.CategoryName))
                {

                    bool result = categoryServie.Create(model);
                    if (result)
                    {
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ModelState.AddModelError("CategoryName", "Duplicate Category Name!");
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
            CategoryDTOs model = categoryServie.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CategoryDTOs model)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            if (ModelState.IsValid)
            {
                bool result = categoryServie.Update(model);
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
            CategoryDTOs model = categoryServie.GetById(id);
            return View(model);
        }


        public ActionResult Delete(Guid id)
        {

            ResturantManagementDBEntities db = new ResturantManagementDBEntities();
            {
                var model = db.Categories.Find(id);
                db.Categories.Remove(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}