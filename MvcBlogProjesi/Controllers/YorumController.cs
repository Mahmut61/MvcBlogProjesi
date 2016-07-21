using MvcBlogProjesi.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProjesi.Controllers
{
    public class YorumController : Controller
    {
        BlogDbContext dc = new BlogDbContext();
        public ActionResult Index()
        {
            List<Yorum> yorumListe = (from y in dc.Yorums
                                      orderby y.Tarih descending
                                      select y).ToList();
            return View(yorumListe);
        }
        public ActionResult yorumJson()
        {
            return View();
        }
        public ActionResult GelenYorum(Yorum model)
        {
            return View();
        }
    }
}