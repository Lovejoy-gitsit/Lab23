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
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();

            ViewBag.ItemsList = ORM.items.ToList();
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

        public ActionResult Add(string FirstName, string LastName, string Email, string Phone, string Password )
        {
            if (ModelState.IsValid)
            {
                CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();
                user newUser = new user();
                newUser.FirstName = FirstName;
                newUser.LastName = LastName;
                newUser.Email = Email;
                newUser.Phone = Phone;
                newUser.Password = Password;
                ORM.users.Add(newUser);
                ORM.SaveChanges();
                newUser = ORM.users.FirstOrDefault(x => x.Email == newUser.Email);
                ViewBag.UserID = newUser.UserID;

                ViewBag.Message = "Confirmed";
                return View("Registration");
                
            }
            else
            {
                ViewBag.Message = "There was an error";
                return View("Error");
            }

        }

        public ActionResult SaveNewItem(item newItem, int userID)
        {
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();
            if (ModelState.IsValid)
            {
                newItem.UserID = userID;
                ORM.items.Add(newItem);
                ORM.SaveChanges();

                ViewBag.ItemsList = ORM.items.ToList();
                ViewBag.userID = userID;
                return View("Admin");
            }
            else
            {
                ViewBag.Message = "Error";
                return View("Error");
            }
        }

        public ActionResult AddItem(int userID)
        {
            ViewBag.userID = userID;
            return View();
        }

        public ActionResult Admin()
        {
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();
            ViewBag.ItemsList = ORM.items.ToList();
            return View();
        }

        public ActionResult Edit(string Name)
        {
            //created ORM
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();

            //locate item to update
            item toUpdate = ORM.items.Find(Name);
            return View(toUpdate);
        } 
        
        public ActionResult Saveitem(item updateditem)
        {
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();

            item Olditem = ORM.items.Find(updateditem.Name);
            if (Olditem != null && ModelState.IsValid)
            {
                Olditem.Name = updateditem.Name;
                Olditem.Description = updateditem.Description;
                Olditem.Quantity = updateditem.Quantity;
                Olditem.Price = updateditem.Price;

                //then modify the new data and enter into the database
                ORM.Entry(Olditem).State = System.Data.Entity.EntityState.Modified;
                //Save changes
                ORM.SaveChanges();
                return RedirectToAction("Admin");
            }
            else
            {
                ViewBag.ErrorMessage = "Item not edited";
                return View("Error");
            }
        }

        public ActionResult Delete(int TaskID)
        {
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();
            item deleteditem = ORM.items.FirstOrDefault(x => x.TaskID == TaskID);
            try

            {
                ORM.items.Remove(deleteditem);
                ORM.SaveChanges();
            }
            catch
            {
                ViewBag.Message = "Error";
                
                return View("Error");
            }
            ViewBag.ItemsList = ORM.items.ToList();
            return View("Admin");

        }

        
            
    }
}