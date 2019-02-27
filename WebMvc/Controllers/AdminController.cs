using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMvc.Models;

namespace WebMvc.Controllers
{
    public class AdminController : Controller
    {
        AppDbContext db = new AppDbContext();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        
    }
}