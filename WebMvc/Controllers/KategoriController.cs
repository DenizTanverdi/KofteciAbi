using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebMvc.Models;

namespace WebMvc.Controllers
{
    public class KategoriController : Controller
    {
        private AppDbContext db = new AppDbContext();
        DateTime dt;
        // GET: Kategori
        public ActionResult Index()
        {
            return View(db.Kategori.ToList());
        }

        // GET: Kategori/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategori kategori = db.Kategori.Find(id);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            return View(kategori);
        }

        // GET: Kategori/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DosyaYukle(System.Web.HttpPostedFileBase yuklenecekDosya)
        {
            if (yuklenecekDosya != null)
            {
                string dosyaYolu = Path.GetFileName(yuklenecekDosya.FileName);
                var yuklemeYeri = Path.Combine(Server.MapPath("~/Images"), dosyaYolu);
                yuklenecekDosya.SaveAs(yuklemeYeri);
            }
            return View();
        }
        // POST: Kategori/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,KategoriAdi,url,Acıklama")] Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                kategori.OlusturmaTarihi = DateTime.Now;
                kategori.GuncellemeTarihi = DateTime.Now;
                db.Kategori.Add(kategori);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kategori);
        }

        // GET: Kategori/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategori kategori = db.Kategori.Find(id);
            dt = kategori.OlusturmaTarihi;
            if (kategori == null)
            {
                return HttpNotFound();
            }
            return View(kategori);
        }

        // POST: Kategori/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,KategoriAdi,url,Acıklama")] Kategori kategori)
        {
       
            if (ModelState.IsValid)
            {
                kategori.GuncellemeTarihi = DateTime.Now;
                kategori.OlusturmaTarihi = DateTime.Now;
                db.Entry(kategori).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kategori);
        }

        // GET: Kategori/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategori kategori = db.Kategori.Find(id);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            return View(kategori);
        }

        // POST: Kategori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kategori kategori = db.Kategori.Find(id);
            db.Kategori.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
