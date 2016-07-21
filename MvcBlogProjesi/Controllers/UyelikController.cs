using MvcBlogProjesi.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProjesi.Controllers
{
    public class UyelikController : Controller
    {
        BlogDbContext dc = new BlogDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult UyeListesi()
        {
            var liste = (from u in dc.Uyes
                         select new { uye = u.Ad + " " + u.Soyad, email = u.Email }).ToList();
            return Json(liste, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (!ModelState.IsValid) { return View(); }
            Uye u = new Uye();
            u.Ad = model.Ad;
            u.Soyad = model.Soyad;
            u.Email = model.Email;
            u.Sifre = model.Sifre;
            u.Tarih = DateTime.Now.ToShortDateString();
            dc.Uyes.Add(u);
            dc.SaveChanges();
            return RedirectToAction("UyelikBasarili");
        }
        public ActionResult UyelikBasarili()
        {
            return View();
        }
        public ActionResult UyeGiris()
        {
            return View();
        }
        [HttpPost]
        //[ActionName("UyeGiris")]
        public string UyeGiris(string Email, string Sifre)
        {
            //string email = Request.Form["Email"];
            //string sifre = Request.Form["Sifre"];
            var uye = (from u in dc.Uyes
                       where u.Email == Email && u.Sifre == Sifre
                       select u).FirstOrDefault();
            if (uye == null)
                return "Hatalı email yada şifre girişi!";
            Session["uye"] = uye.UyeId;

            return "Hoşgeldiniz...<script type='text/javascript'>setTimeout(function(){window.location='/'}, 3000);</script>";
        }
    }
}