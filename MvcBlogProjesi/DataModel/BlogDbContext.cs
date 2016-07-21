using MvcBlogProjesi.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcBlogProjesi.DataModel
{        
    //DbContext sınıfından implement edilmeli, böylece bu sınıfın özelliklerinden yararlanabiliriz. Veritabanı oluşturulurken WebConfig içerisindeki ConnectionString dikkate alınacağından, oluşmasını istediğimiz veritabanının özelliklerini webconfig içerisinde belirtmeliyiz.
    //Burada dikkat edilmesi gereken en önemli nokta, add name ismi ile dbcontext sınıfımızın ismi mutlaka aynı olmalıdır.
    public class BlogDbContext : DbContext
    {
        //Migration işlemleri için DbContext ile Migration eşleştirilmelidir.
        public BlogDbContext() : base("BlogDbContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogDbContext, Configuration>("BlogDbContext"));
        }
        //Veritabanımızda oluşmasını istediğimiz tablolara karşılık gelmek üzere tüm sınıflarımızı DbSet içerisinde çağırmalıyız.
        public DbSet<Uye> Uyes { get; set; }
        public DbSet<Makale> Makales { get; set; }
        public DbSet<Yorum> Yorums { get; set; }
        public DbSet<Etiket> Etikets { get; set; }


    }
}