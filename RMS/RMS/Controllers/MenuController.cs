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
    public class MenuController : Controller
    {
        private readonly MenuService menuService = new MenuService();
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            var menus = menuService.GetAll();
            return View(menus);
        }

        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            MenuDTOs model = new MenuDTOs();
            menuService.CreateSelectList(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(MenuDTOs model)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            if (ModelState.IsValid)
            {
                if (!menuService.MenuNameValidation(model.MenuName))
                {
                    bool result = menuService.Create(model);
                    if (result)
                    {
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ModelState.AddModelError("MenuName", "Duplicate Menu Name!");
                }

            }
            menuService.CreateSelectList(model);
            return View(model);
        }

        public ActionResult Edit(Guid id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            MenuDTOs model = menuService.GetById(id);
            menuService.CreateSelectList(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(MenuDTOs model)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            if (ModelState.IsValid)
            {
                bool result = menuService.Update(model);
                if (result)
                {
                    return RedirectToAction("Index");
                }

            }
            menuService.CreateSelectList(model);
            return View(model);
        }
        public ActionResult Details(Guid id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            MenuDTOs model = menuService.GetById(id);
            return View(model);
        }


        public ActionResult Delete(Guid id)
        {

            ResturantManagementDBEntities db = new ResturantManagementDBEntities();
            {
                var model = db.Menus.Find(id);
                db.Menus.Remove(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}