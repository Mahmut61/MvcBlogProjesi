using MvcBlogProjesi.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProjesi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        BlogDbContext dc = new BlogDbContext();
        public ActionResult SonMakaleler()
        {
            //AraKatmandaki(DbContext) Makaleler sınıfından son eklenen 3 makaleyi görüntüleyecek PartialView için modelListe oluşturmalıyız.
            List<Makale> makaleListe = dc.Makales.OrderByDescending(m => m.Tarih).Take(3).ToList();
            return PartialView(makaleListe);
        }
        public ActionResult SonYorumlar()
        {
            //AraKatmandaki(DbContext) Makaleler sınıfından son eklenen 3 makaleyi görüntüleyecek PartialView için modelListe oluşturmalıyız.
            List<Yorum> yorumListe = dc.Yorums.OrderByDescending(y => y.Tarih).Take(3).ToList();
            return PartialView(yorumListe);
        }
        public ActionResult CokKullanilanEtiketler()
        {
            //En çok makaleyle ilişkilendirilen 5 adet etiketi görüntüleyecek PartialView için modelListe oluşturmalıyız.
            List<Etiket> etiketListe = (from e in dc.Etikets
                                        orderby e.Makales.Count descending
                                        select e).Take(5).ToList();
            return PartialView(etiketListe);
        }
        public ActionResult MakalelerByEtiket(int ID)
        {
            var makaleListe = (from e in dc.Etikets
                               where e.EtiketId == ID
                               select e.Makales).ToList();
            return View(makaleListe[0]); //Burada veriler içiçe liste(koleksiyon) halinde geldiği için (ki çoğunlukla sadece 1 tane olacaktır) içerideki ilk listeyi [0] indeksi ile çekip gönderiyoruz.
        }
        public ActionResult MakaleByYorum(int ID)
        {
            Makale yorumMakale = (from y in dc.Yorums
                               where y.YorumId == ID
                               select y.Makale).FirstOrDefault();
            return View(yorumMakale);
        }
    }
}