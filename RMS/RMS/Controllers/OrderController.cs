using DatabaseLayer;
using RMS.Model.Services;
using RMS.Model.viewModes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;


namespace RMS.Controllers
{

    public class OrderController: Controller
    {
        private ResturantManagementDBEntities db = new ResturantManagementDBEntities();

        public readonly OrderService orderService = new OrderService();
        public readonly OrderItemsService orderItemsService = new OrderItemsService();
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            var orders = orderItemsService.GetAll();
            return View(orders);
        }
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            ViewBag.VendorID = new SelectList(db.Vendors.ToList(), "VendorID","VendorName" );
            var products = db.InventoryProducts.ToList().Select(m => new DropDownOrder { Id = m.InventoryProductID, Name = m.ProductsName }).ToList();


            //NULL ERROR
            List<OrderItems> orderItems = new List<OrderItems>() { new OrderItems { Quantity = 0, SubTotal = 0, InventoryProductID = db.InventoryProducts.FirstOrDefault().InventoryProductID } };
            OrderDTOs orderDTOs = new OrderDTOs
            {
                DDItems = products,
                OrderItems = orderItems
            };

            orderService.CreateSelectList(orderDTOs);
            return View(orderDTOs);

        }
        [HttpPost]
        public ActionResult Create(OrderDTOs model)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            ViewBag.VendorID = new SelectList(db.Vendors.ToList(), "VendorID", "VendorName", model.VendorID);
            var order = db.InventoryProducts.ToList().Select(m => new DropDownOrder { Id = m.InventoryProductID, Name = m.ProductsName }).ToList();
            model.DDItems = order;

            if(ModelState.IsValid)
            {
                double total = 0;
                Order ord = new Order
                {

                    OrderTime = model.OrderTime,
                    OrderDate = model.OrderDate,
                    VendorID = model.VendorID,
                    OrderName = model.OrderName,
                    Total = model.OrderItems.Sum(x => x.SubTotal).ToString()
                   
                    //InventoryProductID = model.InventoryProductID
                };
                
                ord.OrderID = Guid.NewGuid();
                db.Orders.Add(ord);
                db.SaveChanges();
                //var orderItems = new List<OrderItem>();
                foreach (var item in model.OrderItems)
                {
                    total += item.SubTotal;
                   // orderItems.Add(new OrderItem
                    OrderItem orderItems1 = new OrderItem
                    {
                        
                        Price = item.Price,
                        Quantity = item.Quantity,
                        InventoryProductID = item.InventoryProductID
                    };

                    ord.Total = total.ToString();
                   orderItems1.OrderID = ord.OrderID;
                    
                    orderItems1.ItemID = Guid.NewGuid();
                    db.OrderItems.Add(orderItems1);
                    db.SaveChanges();
                    ProductQuantity objStock = db.ProductQuantities.FirstOrDefault(m => m.InventoryProductID == item.InventoryProductID);
                    objStock.Quantity += item.Quantity;
                    db.SaveChanges();

                }

                orderService.CreateSelectList(model);
                return RedirectToAction("Index");

            }
            else
            {
                return View(model);
            }


        }


        public ActionResult Edit(Guid id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            OrderDTOs model = orderService.GetById(id);
            orderService.CreateSelectList(model);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(OrderDTOs model)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            if (ModelState.IsValid)
            {
                bool result = orderService.Update(model);
                if (result)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        /*public ActionResult Details(Guid id)
        {
            OrderDTOs model = orderService.GetById(id);
            return View(model);
        }
*/

        public ActionResult Details(Guid? orderCartID)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
            {
                IEnumerable<OrderViews> orders = (  from o in db.Orders
                                                    join oI in db.OrderItems on o.OrderID equals oI.OrderID
                                                    join v in db.Vendors on o.VendorID equals v.VendorID
                                                    join i in db.InventoryProducts on oI.InventoryProductID equals i.InventoryProductID
                                                    where o.OrderID == orderCartID
                                                      select new OrderViews()
                                                      {
                                                          OrderID = o.OrderID,
                                                          OrderDate = o.OrderDate,
                                                          OrderName = o.OrderName,
                                                          Total = o.Total,
                                                          VenderName = v.VendorName,
                                                          ProductsName = i.ProductsName,
                                                          Quantity = oI.Quantity,
                                                          Price = oI.Price,
                                                          //SubTotal = (int)(Convert.ToInt32(oI.Price) * oI.Quantity),
                                                      }
                                                        ).ToList();



                return View(orders);
            }
        }
        public ActionResult Delete(Guid id)
        {

            ResturantManagementDBEntities db = new ResturantManagementDBEntities();
            {
                var model = db.Orders.Find(id);
                db.Orders.Remove(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}