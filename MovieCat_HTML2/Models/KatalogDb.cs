using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MovieCat_HTML2.Models
{
    public class KatalogDb:DbContext
    {
        public DbSet<Katalog>Katalogs{ get; set; }

    }
}