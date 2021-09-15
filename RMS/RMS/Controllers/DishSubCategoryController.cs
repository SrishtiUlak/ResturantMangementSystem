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
    public class DishSubCategoryController : Controller
    {

        private readonly DishSubCategoryService dishSubCategoryService = new DishSubCategoryService();
        // GET: DishSubCategory
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            var dishSubCategories = dishSubCategoryService.GetAll();
            return View(dishSubCategories);
        }
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            DishSubCategoryDTOs model = new DishSubCategoryDTOs();
            dishSubCategoryService.CreateSelectList(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(DishSubCategoryDTOs dishsub)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            if (ModelState.IsValid)
            {
                bool result = dishSubCategoryService.Create(dishsub);
                if (result == true)
                {
                    return RedirectToAction("Index");
                }
            }
            dishSubCategoryService.CreateSelectList(dishsub);
            return View(dishsub);
        }

        public ActionResult Edit(Guid id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            DishSubCategoryDTOs model = dishSubCategoryService.GetById(id);
            dishSubCategoryService.CreateSelectList(model);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(DishSubCategoryDTOs model)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            if (ModelState.IsValid)
            {
                bool result = dishSubCategoryService.Update(model);
                if (result)
                {
                    return RedirectToAction("Index");
                }

            }
            dishSubCategoryService.CreateSelectList(model);
            return View(model);
        }


        public ActionResult Details(Guid id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            DishSubCategoryDTOs model = dishSubCategoryService.GetById(id);
            return View(model);
        }

        public ActionResult Delete(Guid id)
        {

            ResturantManagementDBEntities db = new ResturantManagementDBEntities();
            {
                var dishsub = db.DishSubCategories.Find(id);
                db.DishSubCategories.Remove(dishsub);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

    }
}