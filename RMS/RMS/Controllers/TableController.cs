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
    public class TableController : Controller
    {
        private readonly TableService tableServie = new TableService();
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            var tables = tableServie.GetAll();
            return View(tables);
        }

        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            TableDTOs model = new TableDTOs();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(TableDTOs model)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }

            if (ModelState.IsValid)
            {
                if (!tableServie.TableNameValidation(model.TableName))
                {

                    bool result = tableServie.Create(model);
                    if (result)
                    {
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ModelState.AddModelError("TableName", "Duplicate Table Name!");
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
            TableDTOs model = tableServie.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(TableDTOs model)
        {
            if (ModelState.IsValid)
            {
                bool result = tableServie.Update(model);
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
            TableDTOs model = tableServie.GetById(id);
            return View(model);
        }

        public ActionResult Delete(Guid id)
        {

            ResturantManagementDBEntities db = new ResturantManagementDBEntities();
            {
                var model = db.Tables.Find(id);
                db.Tables.Remove(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}