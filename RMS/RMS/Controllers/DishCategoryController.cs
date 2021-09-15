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
    public class DishCategoryController : Controller
    {
        // GET: DishCategory
        private readonly DishCategoryService dishCategoryService = new DishCategoryService();
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            var dishCategories = dishCategoryService.GetAll();
            return View(dishCategories);
        }
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            DishCategoryDTOs model = new DishCategoryDTOs();
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(DishCategoryDTOs model)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            if (ModelState.IsValid)
            {
                bool result = dishCategoryService.Create(model);
                if (result == true)
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
            DishCategoryDTOs model = dishCategoryService.GetById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(DishCategoryDTOs model)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            if (ModelState.IsValid)
            {
                bool result = dishCategoryService.Update(model);
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
            DishCategoryDTOs model = dishCategoryService.GetById(id);
            return View(model);
        }


        public ActionResult Delete(Guid id)
        {

            ResturantManagementDBEntities db = new ResturantManagementDBEntities();
            {
                var model = db.DishCategories.Find(id);
                db.DishCategories.Remove(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}