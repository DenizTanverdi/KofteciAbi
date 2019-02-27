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
    }
}
