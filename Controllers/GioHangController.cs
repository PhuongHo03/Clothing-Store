using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClotheShop.Models;
namespace ClotheShop.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "DangNhapUser");
            }
            nguoiDung u = (nguoiDung)Session["user"];
            onlineTradeEntities1 db = new onlineTradeEntities1();
            return View(db.chitietdonhangs.Where(c => c.iduser == u.ID).ToList());
        }
        public ActionResult Them(String id)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "DangNhapUser");
            }
            onlineTradeEntities1 db = new onlineTradeEntities1();
            chitietdonhang model = new chitietdonhang();
            var sp = db.sanPhams.Find(id);
            nguoiDung u = (nguoiDung)Session["user"];
            model.tensanpham = sp.tenSP;
            model.idsanpham = sp.maSP;
            model.iduser = u.ID;
            model.dongia = sp.giaBan;
            model.soluong = 1;
            model.imgurlsanpham = sp.hinhDD;
            foreach (var i in db.chitietdonhangs.Where(c => c.iduser == u.ID).ToList())
            {
                if (i.idsanpham == model.idsanpham)
                {
                    return RedirectToAction("Index");
                }
            }
            db.chitietdonhangs.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Xoa(int id)
        {
            onlineTradeEntities1 db = new onlineTradeEntities1();
            var xoa = db.chitietdonhangs.Find(id);
            db.chitietdonhangs.Remove(xoa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sua(String id, int soluong)
        {
            onlineTradeEntities1 db = new onlineTradeEntities1();
            if (soluong <= 0)
            {
                return RedirectToAction("Index");
            }
            var update = db.chitietdonhangs.FirstOrDefault(c => c.idsanpham == id);
            update.soluong = soluong;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}