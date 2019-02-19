using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebMvc.Models
{
    public class Kategori:BaseEntity
    {
        
        public string KategoriAdi { get; set; }
        public string url { get; set; }
        public string Acıklama { get; set; }
        public virtual ICollection<Urunler> Urunler { get; set; }


    }
}