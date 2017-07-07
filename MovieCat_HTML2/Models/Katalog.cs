using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieCat_HTML2.Models
{
    public class Katalog
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public string Genere { get; set; }
        [Required]
        [StringLength(50)]
        public string Director { get; set; }
        [Required]
        
        [DataType(DataType.Date)]
        public DateTime RealeseDate { get; set; }


    }
}