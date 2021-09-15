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
    public class InventoryProductController : Controller
    {
       
       private readonly InventoryProductService inventoryProductService = new InventoryProductService();
       //GET:InventoryProduct
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            var inventoryProduct = inventoryProductService.GetAll();
            return View(inventoryProduct);
        }

        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            InventoryProductDTOs model = new InventoryProductDTOs();
            inventoryProductService.CreateSelectList(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(InventoryProductDTOs Model, ProductQuantity quantityModel)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            if (ModelState.IsValid)
            {
                if (!inventoryProductService.ProductsNameValidation(Model.ProductsName))
                {
                    bool result = inventoryProductService.Create(Model);
                    if (result ==true)
                    {
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ModelState.AddModelError("ProductsName", "Duplicate Products Name!");
                }

            }
            inventoryProductService.CreateSelectList(Model);
            return View(Model);
        }

        public ActionResult Edit(Guid id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            InventoryProductDTOs model = inventoryProductService.GetById(id);
            inventoryProductService.CreateSelectList(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(InventoryProductDTOs model)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            if (ModelState.IsValid)
            {
                bool result = inventoryProductService.Update(model);
                if (result)
                {
                    return RedirectToAction("Index");
                }

            }
            inventoryProductService.CreateSelectList(model);
            return View(model);
        }
        public ActionResult Details(Guid id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            InventoryProductDTOs model = inventoryProductService.GetById(id);
            return View(model);
        }


        public ActionResult Delete(Guid id)
        {

            ResturantManagementDBEntities db = new ResturantManagementDBEntities();
            {
                var model = db.InventoryProducts.Find(id);
                db.InventoryProducts.Remove(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}