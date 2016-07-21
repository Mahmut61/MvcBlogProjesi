using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcBlogProjesi.DataModel
{
    public class Yorum
    {
        public int YorumId { get; set; }

        [Required(ErrorMessage = "Lütfen yorumunuzu giriniz!")]
        public string Icerik { get; set; }

        [Required(ErrorMessage = "Lütfen yorum tarihini giriniz!")]
        [DataType(DataType.DateTime, ErrorMessage = "Lütfen tarih formatına uygun giriniz!")]
        public string Tarih { get; set; }

        //Foreign Key'lerin oluşturulabilmesi için tüm class'lara gerekli referansları oluşturmalıyız.
        //Her yorumu yazan bir üye vardır.
        public virtual Uye Uye { get; set; }

        //Her yorum bir makaleye aittir.
        public virtual Makale Makale { get; set; }
    }
}