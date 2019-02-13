using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMvc.Models
{
    public class Image:BaseEntity
    {
        public string Url { get; set; }
        public string Baslik { get; set; }
        public string Aciklama { get; set; }
    }
}