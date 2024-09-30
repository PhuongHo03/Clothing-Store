using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClotheShop.Models;
using System.Web.Security;
namespace ClotheShop.Areas.Admin.Controllers
{
    public class DangNhapAdminController : Controller
    {
        // GET: Admin/DangNhapAdmin
        public ActionResult Logout()
        {
            Session.Remove("ad");
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "DangNhapUser", new { area = "" });
        }
    }
}