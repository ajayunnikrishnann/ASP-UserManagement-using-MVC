using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_CRUD_MVC.Models;
using System.Web.Mvc;

namespace ASP_CRUD_MVC.Controllers
{
    public class UserController : Controller
    {
        UserDataAccessLayer userDAL = new UserDataAccessLayer();

        public ActionResult Index()
        {
            IEnumerable<User> users = userDAL.GetAllUsers();
            return View(users);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                userDAL.AddUser(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public ActionResult Edit(int id)
        {
            User user = userDAL.GetUserByID(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                userDAL.UpdateUser(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public ActionResult Delete(int id)
        {
            User user = userDAL.GetUserByID(id);
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            userDAL.DeleteUser(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            User user = userDAL.GetUserByID(id);
            return View(user);
        }
    }
}