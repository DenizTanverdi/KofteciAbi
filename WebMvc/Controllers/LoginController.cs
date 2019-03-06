using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using WebMvc.Models;

namespace WebMvc.Controllers
{
    public class LoginController : Controller
    {
        AppDbContext db = new AppDbContext();
        // GET: Login
        DateTime olusturmaTarihi = DateTime.Now;
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoginKontrol(User user)
        {
            var x = db.User.Where(i => i.UserName == user.UserName && i.Password == user.Password).Select(i => i).ToList();
            ViewBag.mesaj = "";
            if (x.Count() == 0)
            {
               
                return Redirect("Index");
            }
            else
            {
                
                return View();
            }

        }
        public PartialViewResult UrunGetir()
        {
            var list = db.Urunler.ToList();

            return PartialView("_urunPartialView", list);
        }
        public PartialViewResult KategoriGetir()
        {
            var list = db.Kategori.ToList();

            return PartialView("_kategoriPartialView", list);
        }
        public PartialViewResult editUrun(int? id)
        {
           
            //foreach ile db.Categories deki kategorileri listemize ekliyoruz
            if (id==null)
            {
                var list = db.Kategori.ToList();

                return PartialView("_kategoriPartialView", list);
            }
            Urunler urunler = db.Urunler.Find(id);
            //Dinamik bir yapı oluşturup kategoriler list mizi view mize göndereceğiz
            //bunun için viewbag kullanıyorum

            olusturmaTarihi = urunler.OlusturmaTarihi;

            ViewBag.kategoriId = new SelectList(db.Kategori, "Id", "KategoriAdi", urunler.kategoriId);
            return PartialView("_urunEditPartialView", urunler);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,kategoriId,UrunAdi,Adet,Fiyat,OlusturmaTarihi")] Urunler urunler)
        {

            urunler.GuncellemeTarihi = DateTime.Now;
            
            urunler.Url = "";
            if (ModelState.IsValid)
            {
                db.Entry(urunler).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect("LoginKontrol");
            }
            ViewBag.kategoriId = new SelectList(db.Urunler, "Id", "UrunAdi", urunler.kategoriId);
            return View(urunler);
        }
        public PartialViewResult detailsUrun(int? id)
        {

            //foreach ile db.Categories deki kategorileri listemize ekliyoruz
            if (id == null)
            {
                var list = db.Kategori.ToList();

                return PartialView("_kategoriPartialView", list);
            }
            Urunler urunler = db.Urunler.Find(id);
            //Dinamik bir yapı oluşturup kategoriler list mizi view mize göndereceğiz
            //bunun için viewbag kullanıyorum

            olusturmaTarihi = urunler.OlusturmaTarihi;

            ViewBag.kategoriId = new SelectList(db.Kategori, "Id", "KategoriAdi", urunler.kategoriId);
            return PartialView("_urunDetailsPartialView", urunler);
        }
        public ActionResult Create()
        {
            ViewBag.kategoriId = new SelectList(db.Kategori, "Id", "KategoriAdi");
            return PartialView("_urunCreatePartialView");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,kategoriId,UrunAdi,Adet,Fiyat,Url")] Urunler urunler)
        {
            
            if (ModelState.IsValid)
            {
                urunler.OlusturmaTarihi = DateTime.Now;
                urunler.GuncellemeTarihi = DateTime.Now;
                db.Urunler.Add(urunler);
                db.SaveChanges();
                 return Redirect("LoginKontrol");
            }

            ViewBag.kategoriId = new SelectList(db.Urunler, "Id", "KategoriAdi", urunler.kategoriId);
            return View(urunler);
        }

        public PartialViewResult Delete(int? id)
        {
           
            Urunler urunler = db.Urunler.Find(id);
          
            return PartialView("_urunDeleteView",urunler);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Urunler urunler = db.Urunler.Find(id);
            db.Urunler.Remove(urunler);
            db.SaveChanges();
            return RedirectToAction("LoginKontrol");
        }
    }
}
