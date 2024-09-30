using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClotheShop.Models;
namespace ClotheShop.Areas.Admin.Controllers
{
    public class QuanLyLoaiController : Controller
    {
        // GET: Admin/QuanLyLoai
        public ActionResult Index()
        {
            if (Session["ad"] == null)
                return RedirectToAction("Login", "DangNhapUser", new { area = "" });
            else
                return View(new onlineTradeEntities1().loaiSPs.ToList());
        }
        public ActionResult Them() {
            if (Session["ad"] == null)
                return RedirectToAction("Login", "DangNhapUser", new { area = "" });
            else
                return View();
        }
        [HttpPost]
        public ActionResult Them(loaiSP l) {
            onlineTradeEntities1 db = new onlineTradeEntities1();
            foreach (var i in db.loaiSPs)
            {
                if (l.maLoai == i.maLoai)
                {
                    ViewBag.Error = "Mã loại đã tồn tại";
                    return View();
                }
            }
            if (l.maLoai == 0) {
                ViewBag.Error = "Vui lòng nhập mã loại";
                return View();
            }
            if (l.tenLoai == null)
            {
                ViewBag.Error = "Vui lòng nhập tên loại";
                return View();
            }
            db.loaiSPs.Add(l);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Xoa(int? maLoai) {
            if (Session["ad"] == null)
                return RedirectToAction("Login", "DangNhapUser", new { area = "" });
            else {
                onlineTradeEntities1 db = new onlineTradeEntities1();
                var r = db.loaiSPs.Find(maLoai);
                db.loaiSPs.Remove(r);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Sua(int? maLoai)
        {
            if (Session["ad"] == null)
                return RedirectToAction("Login", "DangNhapUser", new { area = "" });
            else
                return View(new onlineTradeEntities1().loaiSPs.Find(maLoai));
        }
        [HttpPost]
        public ActionResult Sua(loaiSP l) {
            onlineTradeEntities1 db = new onlineTradeEntities1();
            if (l.tenLoai == null) {
                ViewBag.Error = "Vui lòng nhập tên loại";
                return View(new onlineTradeEntities1().sanPhams.Find(l.maLoai));
            }
            var up = db.loaiSPs.Find(l.maLoai);
            up.maLoai = l.maLoai;
            up.tenLoai = l.tenLoai;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}