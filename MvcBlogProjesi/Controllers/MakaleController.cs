using MvcBlogProjesi.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProjesi.Controllers
{
    public class MakaleController : Controller
    {
        BlogDbContext dc = new BlogDbContext();
        public ActionResult Index()
        {
            List<Makale> makaleListe = dc.Makales.OrderByDescending(m => m.Tarih).ToList();
            return View(makaleListe);
        }
    }
}