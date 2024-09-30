using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClotheShop.Models;
using System.Web.Security;
namespace ClotheShop.Controllers
{
    public class DangNhapUserController : Controller
    {
        // GET: DangNhapUser
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(String Name, String Pass)
        {
            onlineTradeEntities1 db = new onlineTradeEntities1();
            foreach (var i in db.dangNhapAdmins)
            {
                if (Name == i.Name)
                {
                    if (Pass == i.Pass)
                    {
                        Session["ad"] = i;
                        return RedirectToAction("Index", "QuanLySP", new { area = "admin" });
                    }
                }
            }
            foreach (var i in db.nguoiDungs)
            {
                if (Name == i.Name)
                {
                    if (Pass == i.Pass)
                    {
                        Session["user"] = i;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.Error = "Sai tài khoản hoặc mật khẩu";
                        return View();
                    }
                }            
            }
            ViewBag.Error = "Sai tài khoản hoặc mật khẩu";
            return View();
        }
        public ActionResult Logout()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Session.Remove("user");
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}