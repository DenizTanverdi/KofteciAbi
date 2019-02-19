using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebMvc.Models
{
    public class Urunler:BaseEntity
    {
        public int? kategoriId { get; set; }

        [DisplayName("Kategori")]
        [ForeignKey("kategoriId")]
        public virtual Urunler Student { get; set; }
        public string UrunAdi { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public string Url { get; set; }
       
    }
}