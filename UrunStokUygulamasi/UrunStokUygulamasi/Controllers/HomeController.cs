using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UrunStokUygulamasi.Models;

namespace UrunStokUygulamasi.Controllers
{
    
    public class HomeController : Controller
    {
        UrunStokEntities db = new UrunStokEntities();
        public ActionResult Index()
        {
            return RedirectToAction("List","Urun");
        }

        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(LoginUser user)
        {
            if (db.LoginUser.Any(x => x.Username == user.Username))
            {
                ViewBag.Notification = "Bu kullanıcı adı zaten mevcut!";
                return View();
            }
            else
            {
                if(user.Username != null && user.PasswordUs != null && user.RePasswordUs != null)
                {
                    db.LoginUser.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Login", "Home");
                } 
                else { return View(); }
            }
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginUser user)
        {
            var checklogin = db.LoginUser.Where(x => x.Username.Equals(user.Username) && x.PasswordUs.Equals(user.PasswordUs)).FirstOrDefault();
            if (checklogin != null)
            {
                Session["UsernameSS"] = user.Username.ToString();
                FormsAuthentication.SetAuthCookie(user.Username, false);
                return RedirectToAction("List", "Urun");
            }
            else
            {
                ViewBag.Notifitaction = "Kullanıcı adı veya parola hatalı";
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Home");
        }
    }
}