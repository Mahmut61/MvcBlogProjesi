using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcBlogProjesi.DataModel
{
    public class Uye
    {
        public int UyeId { get; set; }

        [Required(ErrorMessage="Lütfen adınızı giriniz!")]
        [StringLength(20, ErrorMessage ="İsim 20 karakterden uzun olmamalıdır!")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Lütfen soyadınızı giriniz!")]
        [StringLength(20, ErrorMessage = "Soyisim 20 karakterden uzun olmamalıdır!")]
        public string Soyad { get; set; }

        [Required(ErrorMessage = "Lütfen email adresinizi giriniz!")]
        [EmailAddress(ErrorMessage = "Email formatına uygun giriniz!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz!")]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }

        [Required(ErrorMessage = "Lütfen üyelik tarihini giriniz!")]
        [DataType(DataType.DateTime, ErrorMessage = "Lütfen tarih formatına uygun giriniz!")]
        public string Tarih { get; set; }
        //Bir üyenin birden çok makalesi olabilir.
        public virtual List<Makale>  Makales { get; set; }

        //Bir üye birden çok yorum yapabilir.
        public virtual List<Yorum> Yorums { get; set; }
    }
}