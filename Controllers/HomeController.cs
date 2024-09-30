using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClotheShop.Models;
namespace ClotheShop.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Product(String name, String type, String search)
        {
            onlineTradeEntities1 p = new onlineTradeEntities1();
            if (search != null)
            {
                return View(p.sanPhams.Where(c => c.tenSP.ToLower().Contains(search.ToLower())));
            }
            if (name != null)
                if (type != null)
                {
                    int t = int.Parse(type);
                    return View(p.sanPhams.Where(x => x.danhCho == name && x.maLoai == t).ToList());
                }
                else return View(p.sanPhams.Where(x => x.danhCho == name).ToList());
            return View(p.sanPhams.ToList());
        }
        public ActionResult Single(String id) {
            if (id != null)
                return View(new onlineTradeEntities1().sanPhams.Find(id));
            return RedirectToAction("Index");
        }
    }
}