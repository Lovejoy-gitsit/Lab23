using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab21.Models;

namespace Lab21.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult UserRegistration()
        {
            string[] UserDetails = { "First Name", "Last Name", "Email", "Phone Number", "Password"};
            ViewBag.UserDetails = User;
            return View();
        }

        public ActionResult Add(user newUser)
        {
            if (ModelState.IsValid)
            {
                CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();

                ORM.users.Add(newUser);
                ORM.SaveChanges();

                ViewBag.Message = "Confirmed";
                return View("Registration");
                
            }
            else
            {
                ViewBag.Message = "There was an error";
                return View("Error");
            }

        }

        public ActionResult ItemList()
        {
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();
            
            ViewBag.ItemsList = ORM.items.ToList();
            return View();
        }

       

        
        

    }
}