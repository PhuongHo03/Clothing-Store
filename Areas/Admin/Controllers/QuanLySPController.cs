using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClotheShop.Models;
namespace ClotheShop.Areas.Admin.Controllers
{
    public class QuanLySPController : Controller
    {
        // GET: Admin/QuanLySP
        public ActionResult Index()
        {
            if (Session["ad"] == null)
                return RedirectToAction("Login", "DangNhapUser", new { area = "" });
            else
                return View(new onlineTradeEntities1().sanPhams.ToList());
        }
        public ActionResult Them() {
            if (Session["ad"] == null)
                return RedirectToAction("Login", "DangNhapUser", new { area = "" });
            else
                return View();
        }
        [HttpPost]
        public ActionResult Them(sanPham sp, HttpPostedFileBase file)
        {
            onlineTradeEntities1 db = new onlineTradeEntities1();
            foreach (var i in db.sanPhams) {
                if (sp.maSP == i.maSP) {
                    ViewBag.Error = "Mã sản phẩm đã tồn tại";
                    return View();
                }
            }
            if (sp.danhCho == null) {
                ViewBag.Error = "Vui lòng nhập thể loại";
                return View();
            }
            if (sp.maSP == null)
            {
                ViewBag.Error = "Vui lòng nhập mã sản phẩm";
                return View();
            }
            if (sp.maLoai == 0)
            {
                ViewBag.Error = "Vui lòng nhập mã loại";
                return View();
            }
            if (sp.tenSP == null)
            {
                ViewBag.Error = "Vui lòng nhập tên sản phẩm";
                return View();
            }
            if (sp.giaBan == 0)
            {
                ViewBag.Error = "Vui lòng nhập giá tiền";
                return View();
            }
            if (sp.dvt == null)
            {
                ViewBag.Error = "Vui lòng nhập đơn vị tiền";
                return View();
            }
            if (sp.soLuong == 0)
            {
                ViewBag.Error = "Vui lòng nhập số lượng";
                return View();
            }
            if (file == null)
            {
                ViewBag.Error = "Chưa nhập ảnh";
                return View();
            }
            String x = Server.MapPath("/images/");
            String y = x + file.FileName.ToLower();
            file.SaveAs(y);
            sp.hinhDD = "/images/" + file.FileName.ToLower();
            db.sanPhams.Add(sp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Xoa(String maSP) {
            if (Session["ad"] == null)
                return RedirectToAction("Login", "DangNhapUser", new { area = "" });
            else
            {
                onlineTradeEntities1 db = new onlineTradeEntities1();
                var r = db.sanPhams.Find(maSP);
                System.IO.File.Delete(Server.MapPath(r.hinhDD));
                db.sanPhams.Remove(r);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Sua(String maSP)
        {
            if (Session["ad"] == null)
                return RedirectToAction("Login", "DangNhapUser", new { area = "" });
            else
            {
                return View(new onlineTradeEntities1().sanPhams.Find(maSP));
            }
        }
        [HttpPost]
        public ActionResult Sua(sanPham sp, HttpPostedFileBase file) {
            onlineTradeEntities1 db = new onlineTradeEntities1();
            if (sp.tenSP == null)
            {
                ViewBag.Error = "Vui lòng nhập tên sản phẩm";
                return View(new onlineTradeEntities1().sanPhams.Find(sp.maSP));
            }
            if (sp.giaBan == 0)
            {
                ViewBag.Error = "Vui lòng nhập giá tiền";
                return View(new onlineTradeEntities1().sanPhams.Find(sp.maSP));
            }
            if (sp.dvt == null)
            {
                ViewBag.Error = "Vui lòng nhập đơn vị tiền";
                return View(new onlineTradeEntities1().sanPhams.Find(sp.maSP));
            }
            if (sp.soLuong == 0)
            {
                ViewBag.Error = "Vui lòng nhập số lượng";
                return View(new onlineTradeEntities1().sanPhams.Find(sp.maSP));
            }
            if (file == null)
            {
                ViewBag.Error = "Chưa nhập ảnh";
                return View(new onlineTradeEntities1().sanPhams.Find(sp.maSP));
            }
            var up = db.sanPhams.Find(sp.maSP);
            up.danhCho = sp.danhCho;
            up.maSP = sp.maSP;
            up.maLoai = sp.maLoai;
            up.tenSP = sp.tenSP;
            up.giaBan = sp.giaBan;
            up.dvt = sp.dvt;
            up.soLuong = sp.soLuong;
            System.IO.File.Delete(Server.MapPath(up.hinhDD));
            String x = Server.MapPath("/images/");
            String y = x + file.FileName.ToLower();
            file.SaveAs(y);
            up.hinhDD = "/images/" + file.FileName.ToLower();
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}