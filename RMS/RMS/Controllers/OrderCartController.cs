using RMS.Model.viewModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DatabaseLayer;
using RMS.Model.viewModes.Base;

namespace RMS.Controllers
{
    public class OrderCartController : Controller
    {

        private ResturantManagementDBEntities DB = new ResturantManagementDBEntities();

        private List<CartDTOs> ListofCart;


        public OrderCartController()
        {
            DB = new ResturantManagementDBEntities();
            ListofCart = new List<CartDTOs>();
        }

        public OrderCartsDTOs CreateSelectList(OrderCartsDTOs model)
        {
            model.CustomerNames = GetCustomers();
            model.TableNames = GetTables();

            return model;
        }

        public List<BaseGuidSelect> GetCustomers()
        {
            using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
            {
                return db.Customers.Select(u =>
                new BaseGuidSelect
                {
                    Id = u.CustomerID,
                    Name = u.CustomerName
                }).ToList();
            }
        }


        public List<BaseGuidSelect> GetTables()
        {
            using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
            {
                return db.Tables.Select(u =>
                new BaseGuidSelect
                {
                    Id = u.TableID,
                    Name = u.TableName
                }).ToList();
            }
        }


        //GET: OrderCart
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            ViewBag.CustomerID = new SelectList(DB.Customers.ToList(), "CustomerID", "CustomerName");
            ViewBag.TableID = new SelectList(DB.Tables.ToList(), "TableID", "TableName");
            IEnumerable<OrderCartDTOs> ListofOrderCarts = (from DBMenu in DB.Menus
                                                           join
                                                           DBSubCategory in DB.DishSubCategories
                                                           on DBMenu.SubCategoryID equals DBSubCategory.SubCategoryID
                                                           select new OrderCartDTOs()
                                                           {
                                                               MenuID = DBMenu.MenuID,
                                                               MenuName = DBMenu.MenuName,
                                                               MenuPrice = DBMenu.MenuPrice,
                                                               ImagePath = DBMenu.ImagePath,
                                                               SubCategory = DBSubCategory.SubCategoryName


                                                           }).ToList();
            return View(ListofOrderCarts);
        }


        [HttpPost]
        public JsonResult Index(Guid MenuId)
        {
            ViewBag.CustomerID = new SelectList(DB.Customers.ToList(), "CustomerID", "CustomerName");
            ViewBag.TableID = new SelectList(DB.Tables.ToList(), "TableID", "TableName");
            CartDTOs dTOs = new CartDTOs();
            Menu menu = DB.Menus.Single(model => model.MenuID == MenuId);
            if (Session["CartCounter"] != null)
            {
                ListofCart = Session["CartItem"] as List<CartDTOs>;
            }
            if (ListofCart.Any(model => model.MenuId == MenuId))
            {
                dTOs = ListofCart.Single(model => model.MenuId == MenuId);
                
                dTOs.Quantity++;
                dTOs.Total = dTOs.Quantity * dTOs.UnitPrice;
            }
            else
            {
                dTOs.MenuId = MenuId;
                dTOs.MenuName = menu.MenuName;
                dTOs.ImagePath = menu.ImagePath;
                dTOs.Quantity = 1;
                dTOs.Total = Convert.ToDecimal(menu.MenuPrice);
                dTOs.UnitPrice = Convert.ToDecimal(menu.MenuPrice);
                
               
                
                ListofCart.Add(dTOs);

            }

            Session["CartCounter"] = ListofCart.Count;
            Session["CartItem"] = ListofCart;
            return Json(new { Success = true, Counter = ListofCart.Count }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult OrderCart()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            ListofCart = Session["CartItem"] as List<CartDTOs>;
            OrderCartsDTOs ordercart = new OrderCartsDTOs();
            ordercart.Carts = ListofCart;
            ordercart.CustomerNames = GetCustomers();
            ordercart.TableNames = GetTables();
            ordercart.Total = ListofCart.Sum(x => x.Total);
            return View(ordercart);
        }

        [HttpPost]
        public ActionResult AddOrder(OrderCartsDTOs model)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            ///int OrderCartId = 10;

            ListofCart = model.Carts;
            OrderCart orderCart = new OrderCart()
            {
                OrderDate = DateTime.Now,
                OrderNumber = String.Format("(0:ddmmyyyyhhmmss)", DateTime.Now),
                OrderStatus = false
                //OrderCartID = OrderCartId + 1, 
            };
            Invoice invoice = new Invoice()
            {
                InvoiceID = Guid.NewGuid(),
                Status = false,
               // OrderCartID = orderCart.OrderCartID


            };
            orderCart.Invoices.Add(invoice);

            //OrderCartId = orderCart.OrderCartID;
            foreach (var item in ListofCart)
            {
                CartDetail cartModel = new CartDetail();
                cartModel.Total = item.Total;

                cartModel.MenuID = item.MenuId;
                cartModel.Quantity = item.Quantity;
                cartModel.Price = item.UnitPrice;
                cartModel.CustomerID = model.CustomerID;
                cartModel.TableID = model.TableID;  
                
               


                orderCart.CartDetails.Add(cartModel);
               

            }
            DB.OrderCarts.Add(orderCart);
            DB.SaveChanges();
            Session["CartItem"] = null;
            Session["CartCounter"] = null;
            return RedirectToAction("Index");
        }

    }

}