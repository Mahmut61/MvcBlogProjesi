using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcBlogProjesi.DataModel
{
    public class Makale
    {
        public int MakaleId { get; set; }

        [Required(ErrorMessage = "Lütfen makale başlığını giriniz!")]
        [StringLength(50, ErrorMessage = "Başlık 20 karakterden uzun olmamalıdır!")]
        public string Baslik { get; set; }

        [Required(ErrorMessage = "Lütfen makale içeriğini giriniz!")]
        [DataType(DataType.Html, ErrorMessage = "Makale içeriğini Html formatına uygun giriniz!")]
        public string Icerik { get; set; }

        [Required(ErrorMessage = "Lütfen makale tarihini giriniz!")]
        [DataType(DataType.DateTime, ErrorMessage = "Lütfen tarih formatına uygun giriniz!")]
        public string Tarih { get; set; }
        //Her makaleyi yazan bir üye vardır.
        public virtual Uye Uye { get; set; }

        //Bir makaleye birden çok yorum yapılabilir.
        public virtual List<Yorum> Yorums { get; set; }

        //Bir makalede birden çok etiket bulunabilir.
        public virtual List<Etiket> Etikets { get; set; }
    }
}