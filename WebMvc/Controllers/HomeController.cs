using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMvc.Models;

namespace WebMvc.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext db = new AppDbContext();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.kategoriListele = db.Kategori.ToList();
            ViewBag.urunListele = db.Urunler.ToList();
            return View(db.Image.ToList());
        }
    }
}