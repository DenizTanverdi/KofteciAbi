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
        public ActionResult LoginKontrol(int? id)
        {
            return View();
        }
    }
}