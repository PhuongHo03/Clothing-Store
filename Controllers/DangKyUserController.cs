using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClotheShop.Models;
namespace ClotheShop.Controllers
{
    public class DangKyUserController : Controller
    {
        // GET: DangKyUser
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(nguoiDung model) {
            onlineTradeEntities1 db = new onlineTradeEntities1();
            if (model.Name == null) {
                ViewBag.Error = "Vui lòng nhập tên đăng nhập";
                return View();
            }
            if (model.Pass == null)
            {
                ViewBag.Error = "Vui lòng nhập mật khẩu";
                return View();
            }
            db.nguoiDungs.Add(model);
            db.SaveChanges();
            return RedirectToAction("Login", "DangNhapUser");
        }
    }
}