using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebMvc.Models;

namespace WebMvc.Controllers
{
    public class LoginController : Controller
    {
        AppDbContext db = new AppDbContext();
        // GET: Login
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
            List<SelectListItem> kategoriler = new List<SelectListItem>();
            //foreach ile db.Categories deki kategorileri listemize ekliyoruz
            foreach (var item in db.Kategori.ToList())
            {   //Text = Görünen kısımdır. Kategori ismini yazdıyoruz
                //Value = Değer kısmıdır.ID değerini atıyoruz
                kategoriler.Add(new SelectListItem { Text = item.KategoriAdi, Value = item.Id.ToString() });
            }
            //Dinamik bir yapı oluşturup kategoriler list mizi view mize göndereceğiz
            //bunun için viewbag kullanıyorum
            ViewBag.Kategoriler = kategoriler;


            var list = db.Urunler.Find(id);

            return PartialView("_urunEditPartialView", list);
        }
    }
}
