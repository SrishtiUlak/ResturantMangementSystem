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
    public class UserController : Controller
    {
        private ResturantManagementDBEntities db = new ResturantManagementDBEntities();
        private readonly UserService userService = new UserService();
        // GET: User
        public ActionResult Index()
        {           
            var user = userService.GetAll();
            return View(user);
        }
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            UserDTOs model = new UserDTOs();
            userService.CreateSelectList(model);
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(UserDTOs model, string ConfirmPassword)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            if (ModelState.IsValid)
            {
                if (!userService.UserNameValidation(model.UserName))
                {
                    if (!userService.EmailValidation(model.Email))
                    {
                        if (!userService.PhoneNoValidation(model.PhoneNumber))
                        {
                            bool result = userService.Create(model, ConfirmPassword);
                            if (result == true)
                            {

                                return RedirectToAction("Index");
                            }
                            if (result == false)
                            {
                                ViewBag.Message = "Your password and Confirm Password doesn't match";

                            }

                        }
                        else
                        {
                            ModelState.AddModelError("PhoneNumber", "This Phone Number is already used");
                        }

                    }
                    else
                    {
                        ModelState.AddModelError("Email", "This email is already used");
                    }

                }
                else
                {
                    ModelState.AddModelError("UserName", "Duplicate User Name!");
                }


            }
            userService.CreateSelectList(model);
            return View(model);
        }

        public ActionResult Edit(Guid id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            UserDTOs model = userService.GetById(id);
            userService.CreateSelectList(model);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(UserDTOs model)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            if (ModelState.IsValid)
            {
                bool result = userService.Update(model);
                if (result)
                {
                    return RedirectToAction("Index");
                }

            }
            userService.CreateSelectList(model);
            return View(model);
        }

        public ActionResult Details(Guid id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            UserDTOs model = userService.GetById(id);
            return View(model);
        }


        public ActionResult Delete(Guid id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "User");
            }
            ResturantManagementDBEntities db = new ResturantManagementDBEntities();
            {
                var model = db.Users.Find(id);
                db.Users.Remove(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Register()
        {
            UserDTOs model = new UserDTOs();
            userService.CreateSelectList(model);
            return View(model);
        }
        [HttpPost]
        public ActionResult Register(UserDTOs model, string ConfirmPassword)
        {
            if (ModelState.IsValid)
            {
                if (!userService.UserNameValidation(model.UserName))
                {
                    bool result = userService.Create(model, ConfirmPassword);
                    if (result == true)
                    {

                        return RedirectToAction("Login");
                    }
                    if (result == false)
                    {
                        ViewBag.Message = "Your password and Confirm Password doesn't match";

                    }
                }
                else
                {
                    ModelState.AddModelError("UserName", "Duplicate User Name!");
                }


            }
            userService.CreateSelectList(model);
            return View(model);
        }

            

        public void Logout()
        {
            Session["UserId"] = string.Empty;
            Session["FirstName"] = string.Empty;
            Session["LastName"] = string.Empty;
            Session["PhoneNumber"] = string.Empty;
            Session["Email"] = string.Empty;
            Session["UserName"] = string.Empty;
            Session["Password"] = string.Empty;
            Session["Address"] = string.Empty;
            Session["UserTypeID"] = string.Empty;
            Session["UserType"] = string.Empty;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string password, string email)
        {
            var user = db.Users.Where(u => u.Email == email && u.Password == password ).FirstOrDefault();
            if (user != null)
            {
                Session["UserID"] = user.UserId;
                Session["UserTypeID"] = user.UserTypeID;
                Session["UserName"] = user.UserName;
                Session["FristName"] = user.FristName;
                Session["LastName"] = user.LastName;
                Session["Password"] = user.Password;
                Session["Email"] = user.Email;
                Session["PhoneNumber"] = user.PhoneNumber;
                Session["Address"] = user.Address;
                bool result = userService.Login(password, email);
                if (result)
                {
                   var usertype = user.UserTypeID.ToString().ToUpper();//Waiter
                    if (usertype == "79e6e845-edfb-4061-acce-155e2ab5780a") 
                    {

                    return RedirectToAction("Index", "Home");


                    }                   
                    else if (usertype == "869a04cc-5406-4acc-8f43-36f84b48758f")//Admin
                    {
                        return RedirectToAction("Index", "Home");

                    }
                   else if (usertype == "83d203c2-1f32-41bd-808e-ca740ae4a33a")
                    {
                        return RedirectToAction("Index", "Home");

                    }
                }
                else
                {
                    ViewBag.message = "Either Email or Password does't match";
                }

                if (result == false)
                {
                    ViewBag.message = "Either Email or Password does't match";
                }
            }

            return View();
        }
    }
}